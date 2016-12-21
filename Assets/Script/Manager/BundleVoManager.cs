using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BundleVoManager
{
    private Dictionary<string, BundleVo> tbBundleVo;
    public BundleVoManager()
    {
        tbBundleVo = new Dictionary<string, BundleVo>();
    }

    public bool hasBundle(string bundleName)
    {
        return tbBundleVo.ContainsKey(bundleName);
    }

    public void addBundle(BundleVo vo)
    {
        tbBundleVo.Add(vo.name, vo);
    }

    public bool removeBundle(string bundleName)
    {
        if (tbBundleVo.ContainsKey(bundleName))
        {
            tbBundleVo[bundleName].bundle.Unload(true);
            tbBundleVo[bundleName].bundle = null;
            tbBundleVo.Remove(bundleName);
            return true;
        }
        return false;
    }

    public BundleVo getBundle(string name)
    {
        return tbBundleVo[name];
    }

}

