using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

///1，这个类做bundle文件的计算
public class BundleManager 
{
    private static BundleManager _instance = null; 
    private GameObject bunleLoader; //使用coroutine执行，而不用继承Mon
    private int totalBytesToLoad=0;
    private int totalBytesLoaded=0;
    private List<string> loadList;
    private int allLoadListCount;

    //文件名--版本号
    private Dictionary<string,string> filenameDict = new Dictionary<string,string>();

    private BundleManager()
    {
        System.IO.DirectoryInfo dirinfo = new DirectoryInfo(LMVersion.ASSET_BUNDLE_PATH);
        if(dirinfo.Exists)
        {
            System.IO.FileInfo[] infos= dirinfo.GetFiles();
            foreach(FileInfo fl in infos)
            {
                Debug.Log("获取到目录文件："+fl);
                int underLineIndex = fl.Name.LastIndexOf('_');
                if(underLineIndex!=-1){
                    string bundleName= fl.Name.Substring(0,underLineIndex);
                    string bundleVersion= fl.Name.Substring(underLineIndex+1,fl.Name.Length-underLineIndex-1);
                    if(!filenameDict.ContainsKey(bundleName)){
                        filenameDict.Add(bundleName,bundleVersion);
                    }
                }
            }
        }
        bunleLoader = new GameObject("CoroutineProxyManager");
        bunleLoader.AddComponent<CoroutineProxyManager>();
    }
    public static BundleManager getIns()
    {
        if(_instance == null)
        {
            _instance = new BundleManager();
        }
        return _instance;
    }

    public int TotalBytesToload(List<string> loadlist)
    {
        foreach(string ln in loadlist)
        {

            int underLineIndex = ln.LastIndexOf('_');
            string bundleName = ln.Substring(0,underLineIndex);
            string bundleVersion = ln .Substring(underLineIndex+1 , ln.Length - bundleName.Length -1);
            if(!filenameDict.ContainsKey(bundleName) || !bundleVersion.Equals(filenameDict[bundleName]))
            {
                int sizeCharIndex= ln.LastIndexOf('@'); 
                string size =  ln.Substring(sizeCharIndex+1,ln.Length-sizeCharIndex-1);
                Debug.Log("需要更新的文件"+bundleName +"Size="+size);
                totalBytesToLoad+=int.Parse(size);
                Debug.Log(bundleName+"###"+bundleVersion+"###"+filenameDict[bundleName]+"###"+totalBytesToLoad);
            }
        }
        return totalBytesToLoad;
    }
    public void SetLoadList(List<string> ldlist)
    {
       this.loadList = ldlist; 
       allLoadListCount = ldlist.Count;
    }
    public void StartLoadBundle()
    {
        if(loadList!=null && loadList.Count>0){
        LoadBundles(loadList[0]);
        } 
    }

    private void LoadBundles(string nameWithVersion)
    {
       string[] nameVersionSize=nameWithVersion.Split('_');
       string bundleName=nameVersionSize[0];
       string bundleVersion=nameVersionSize[1];
       string[] ver_size=bundleVersion.Split('@');
       string bundleSize= ver_size[1];
       Debug.Log("进入下载队列文件:"+bundleName+"|"+bundleVersion+"|"+bundleSize);
       
    }
}
