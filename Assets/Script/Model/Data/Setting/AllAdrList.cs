using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine.UI;


public class AllAdrList
{
    public static Dictionary<string,string> list = null;

    public static void  InitList(SecurityElement root)
    {
        list = new Dictionary<string, string>();
        foreach (SecurityElement elem in root.Children)
        {
            string name = elem.Attribute("name");
            string adr = elem.Attribute("path");
            list.Add(name, adr);
        }
    }
}

