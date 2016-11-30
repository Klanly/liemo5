using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class LoadTxt : MonoBehaviour
{
    private Dictionary<string,string> localDic = new Dictionary<string,string>();
    public static LoadTxt GetIns;

    void Awake()
    {
        GetIns = this;
        string txt = StreamLoadTxt();
        string[] strArr = txt.Split('\n');
        for (int i = 0; i < strArr.Length; i++)
        {
            string[] kv = strArr[i].Split('=');
            if (kv.Length >= 2)
            {
                string key = kv[0];
                if (localDic.ContainsKey(key))
                {
                    Debug.LogWarning("重复的key=" + key);
                }
                else
                {
                    localDic.Add(key, kv[1]);
                }
            }
        }
    }

    public string getName(string Key)
    {
        if (localDic.ContainsKey(Key))
        {
            return localDic[Key];
        }
        Debug.LogWarning("Can't Find Language key value->" + Key);
        return "nullLang";
    }

    private string StreamLoadTxt()
    {
        string path = Application.streamingAssetsPath + @"/chinese.txt";
        StreamReader sr = new StreamReader(path, Encoding.Default);
        string strContent = sr.ReadToEnd();
        return strContent;
    }
}
