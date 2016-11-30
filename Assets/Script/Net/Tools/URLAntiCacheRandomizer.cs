using System.Collections;
using UnityEngine;

public  class URLAntiCacheRandomizer
{
    public static string  RandomURL(string url)
    {

        string r = "";
        r += UnityEngine.Random.Range(1000000, 8000000).ToString();
        r += UnityEngine.Random.Range(1000000, 8000000).ToString();
        string result = url + "?p=" + r;
        return result;
    }
}

