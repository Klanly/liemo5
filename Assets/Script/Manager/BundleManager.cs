using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
///1，这个类做bundle文件的计算
public class BundleManager 
{
    private static BundleManager _instance = null; 
    private int totalBytesToLoad=0;
    private int totalBytesLoaded=0;

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


            }
        }
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
            Debug.Log(ln);

        }
        return 1;
    }
}
