using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResoureManager {
    private static ResoureManager _ins = null;
    private static System.Collections.Generic.Dictionary<string,UnityEngine.Object> goPool = new System.Collections.Generic.Dictionary<string,UnityEngine.Object>();
    //private static Dictionary<string,UI> _effectPool = new Dictionary<string,UI>();

    public static ResoureManager getIns()
    {
        if(_ins ==null){
            _ins= new ResoureManager();
        }
        return _ins;
    }

    public UnityEngine.Object this[string str]
    {
        get{
            if(!goPool.ContainsKey(str)) return null;
            return goPool[str];
        }
    }

    public UnityEngine.Object GetObjectByName(string objName)
    {
        UnityEngine.Object obj=null;
        if(!goPool.ContainsKey(objName))
        {
            obj=UnityEngine.Resources.Load(objName);
            if(null == obj)
            {
                Debug.LogError("Load Error:objName="+ objName);
                return null;
            }
            goPool.Add(objName,obj);

        }
        return goPool[objName];
    }

    public GameObject GetGameObjectByName(string gameobjectname)
    {
        Object obj= null;
        obj = GetObjectByName(gameobjectname);
        if(null == obj)
        {
            Debug.LogError("Load Error:gameobjName="+ gameobjectname);
            return null;
        }
        GameObject gameobj = GameObject.Instantiate(obj) as GameObject;
        gameobj.transform.position=UnityEngine.Vector3.zero;
        gameobj.transform.localScale=Vector3.zero;
        return gameobj;
    }
    
    public GameObject GetMainUI(string gameobjName)
    {
       return GetGameObjectByName("Prefab/MainUI/"+gameobjName);
    }

    public void Dispose()
    {
        ObjectPoolManager pool = GameObject.FindObjectOfType<ObjectPoolManager>();
        if(null != pool)
        {
            pool.dispose();
            GameObject.DestroyImmediate(pool);
        }
        goPool.Clear();
        UnityEngine.Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }


}
