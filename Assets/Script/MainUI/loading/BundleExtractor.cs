using UnityEngine;
using System.Collections;
using System.IO;

public class BundleExtractor : MonoBehaviour
{
    public event Intro.OnItemLoadcomplete OnItemLoaded;

    private int totalcount;
    private int currentCount = 0;

    public float percent
    {
        get
        {
            if (totalcount == 0)
            {
                return 1.0f;
            }
            else
            {
                return (float)currentCount / (float)totalcount;
            }
        }
    }

    public void StartLoading(Intro.OnItemLoadcomplete onloaded)
    {
        OnItemLoaded = onloaded;
        if (!Directory.Exists(LMVersion.ASSET_BUNDLE_PATH))
        {
            Directory.CreateDirectory(LMVersion.ASSET_BUNDLE_PATH);
            //CopyToCache ();
        }
        CopyToCache();
    }
    private void callBack()
    {
        if (OnItemLoaded != null)
        {
            OnItemLoaded();
        }
    }

    /// <summary>
    /// 从Stream目录里面把只读文件拷贝到persionData目录里面去。，这里可以写。 也就是以后的assetbundle目录
    /// </summary>
    public void CopyToCache()
    {
        Debug.Log(Application.platform);
        Debug.Log(Application.streamingAssetsPath);
        Debug.Log(Application.persistentDataPath);
        Debug.Log(LMVersion.ASSET_BUNDLE_PATH);

        if (RuntimePlatform.Android == Application.platform)
        {
            StartCoroutine(loadStreamUsingWWW(Application.streamingAssetsPath + "/Android/"));
        }
        else if (RuntimePlatform.IPhonePlayer == Application.platform)
        {
            StartCoroutine(loadStreamUsingWWW(Application.streamingAssetsPath + "/iPhone/Raw/"));
        }
        else if (RuntimePlatform.OSXEditor == Application.platform || RuntimePlatform.WindowsEditor == Application.platform)
        {
            Directory.CreateDirectory(LMVersion.ASSET_BUNDLE_PATH);
            StartCoroutine(loadStreamUsingFile(Application.streamingAssetsPath + "/Pc/"));
        }

    }

    private IEnumerator loadStreamUsingFile(string txtpath)
    {
        string allFiles = System.IO.File.ReadAllText(txtpath + "v.txt");
        string[] fileNames = allFiles.Split('\n');
        foreach (string fname in fileNames)
        {
            if (fname.Equals(""))
            {
                continue;
            }
            Debug.Log(fname);

            string bundleName = string.Empty;
            int underLineIndex = fname.LastIndexOf('_');
            if (underLineIndex != -1)
            {
                bundleName = fname.Substring(0, underLineIndex);
            }
            if (bundleName.Length > 0)
            {
                byte[] bytes = File.ReadAllBytes(txtpath + bundleName);
                if (bundleName.Contains(".assetbundle"))
                {
                    File.WriteAllBytes(Application.persistentDataPath + "/Pc/" + fname, bytes);
                }
                else
                {

                    File.WriteAllBytes(Application.persistentDataPath + "/Pc/" + fname, bytes);
                }
            }
            else
            {
                Debug.Log("错误的本地Cache数据" + fname);
            }
            yield return new WaitForEndOfFrame();

        }
        yield return new WaitForEndOfFrame();
        callBack();
    }
    private IEnumerator loadStreamUsingWWW(string txtpath)
    {
        WWW www = new WWW(txtpath + "/v.txt");
        yield return www;
        Debug.Log(txtpath);
        if (www.error == null && www.isDone)
        {
            string[] fileNames = www.text.Split('\n');
            int len = fileNames.Length;
            foreach (string fn in fileNames)
            {
                Debug.Log(fn);
            }
        }
        else
        {
            Debug.Log(www.error);
        }
    }
}
