using UnityEngine;
using System.Collections;


public class CoroutineProxyManager : MonoBehaviour {
    public delegate IEnumerator CoroutineMethod();
    private static  CoroutineProxyManager _instance;
    public static CoroutineProxyManager getIns(){
        if(_instance==null){
            Debug.LogError("模块没有初始化"); 
        }
        return _instance;
    }

    void Awake(){
        _instance=this;
        Debug.Log("Hello");
    }

    public void StartCoroutineDelegate(CoroutineMethod method){
        StartCoroutine("RunCoroutine",method);
    }

    public IEnumerator RunCoroutine(CoroutineMethod method){
        return method();
    }
}
