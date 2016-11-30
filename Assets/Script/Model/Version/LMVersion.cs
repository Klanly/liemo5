using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;

public  static class LMVersion
{
    public static string ASSET_BUNDLE_PATH = Application.persistentDataPath;
#if UNITY_ANDROID
    public static string Version_PATH = ASSET_BUNDLE_PATH + "/Android/Version.txt";
#elif UNITY_IPHONE
    public static string Version_PATH = ASSET_BUNDLE_PATH + "/iPhone/Version.txt";
#elif UNITY_EDITOR
    public static string Version_PATH = ASSET_BUNDLE_PATH + "/PC/Version.txt";
#endif




    public static string getVersion()
    {
        return Version_PATH;
    }

    public static void Create(string content)
    {
        System.IO.File.WriteAllText(Version_PATH, content);
    }

    public static string getVersion_list()
    {
        Debug.Log(Version_PATH);
        string strContent = string.Empty;
        if (System.IO.File.Exists(Version_PATH))
        {
            StreamReader sr = new StreamReader(Version_PATH, Encoding.Default);
            strContent = sr.ReadToEnd();
        }
        else
        {
            TextAsset sr = Resources.Load("Version", typeof(TextAsset)) as TextAsset;
            strContent = sr.ToString();

        }
        Debug.Log(strContent);
        return strContent;

    }
}

