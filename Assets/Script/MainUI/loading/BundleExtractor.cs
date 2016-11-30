using UnityEngine;
using System.Collections;
using System.IO;

public class BundleExtractor : MonoBehaviour
{
    public event Intro.OnItemLoadcomplete OnItemLoaded;

    private int totalcount;
    private int currentCount = 0;

    public float percent {
        get {
            if (totalcount == 0) {
                return 1.0f;
            } else {
                return (float)currentCount / (float)totalcount;
            }
        }
    }

    public void StartLoading (Intro.OnItemLoadcomplete onloaded)
    {
        OnItemLoaded = onloaded;
        if (!Directory.Exists (LMVersion.ASSET_BUNDLE_PATH)) {
            Directory.CreateDirectory (LMVersion.ASSET_BUNDLE_PATH);
            CopyToCache ();
        }
        CopyToCache ();
    }

    /// <summary>
    /// 从Stream目录里面把只读文件拷贝到persionData目录里面去。，这里可以写。 也就是以后的assetbundle目录
    /// </summary>
    public void CopyToCache ()
    {
        Debug.Log (Application.platform);
        Debug.Log (Application.streamingAssetsPath);
        Debug.Log (Application.persistentDataPath);
        Debug.Log (LMVersion.ASSET_BUNDLE_PATH);

        if (RuntimePlatform.Android == Application.platform) {
            StartCoroutine (loadStreamUsingWWW (Application.streamingAssetsPath + "/Android/"));
        }else if(RuntimePlatform.IPhonePlayer == Application.platform)
        {
            StartCoroutine(loadStreamUsingWWW(Application.streamingAssetsPath+"/iPhone/Raw/"));
        }else if(RuntimePlatform.OSXEditor == Application.platform || RuntimePlatform.WindowsEditor == Application.platform)
        {
            StartCoroutine(loadStreamUsingFile(Application.streamingAssetsPath+"/Pc/"));
        }

    }

    private IEnumerator loadStreamUsingFile(string txtpath)
    {
        string allFiles=System.IO.File.ReadAllText(txtpath+"v.txt");
        string[] fileNames= allFiles.Split('\n');
        foreach(string fname in fileNames)
        {
            if(fname.Equals(""))
            {
                continue;
            }
            Debug.Log(fname);
            string[] content=fname.Split(',');
            if(content[0].Length>0 && content[1].Length>0 && content[2].Length>0)
            {
                Debug.Log(content[0]+":"+content[1]);
            }

        }
        yield return new WaitForEndOfFrame(); 
    }
    private IEnumerator loadStreamUsingWWW (string txtpath)
    {
        WWW www = new WWW (txtpath + "/v.txt");
        yield return www;
        Debug.Log (txtpath);
        if (www.error == null && www.isDone) 
        {
            string[] fileNames = www.text.Split ('\n');
            int len = fileNames.Length;
            foreach (string fn in fileNames) {
                Debug.Log (fn);
            }
        }else{
            Debug.Log(www.error);
        }
    }
}
