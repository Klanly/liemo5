using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour {

    private static ObjectPoolManager _instance;
    private Dictionary<string,GameObject> _pooledGameObjects= new Dictionary<string,GameObject>();
    private int _poolSize;
    public Dictionary<string,string> monsterNames;
    public Dictionary<string,string> playerEffectNames;
    public Dictionary<string,string> monsterEffectNames;

    private List<GameObject> pooledEffects;
    private string[] zhanshi = { "zhanshi_baolichongzhuang_cs", "Effect_zhanshichongzhuang", "zhanshidaoguangtexiao3", "Zhanshi_handizhenji", "zhanshi_xuanfengzhan", "buff_zhandouli", "guaiwunuhou", "zhanhou", "zhanshidaoguangtexiao1", "zhanshidaoguangtexiao2", "Skill_Sword"  };
    private string[] fashi = { "buff_jiasu", "Fashitexiao_shanshuo1", "Fashitexiao_shanshuo2", "fashi_tongyongshifa", "Fashitexiao_binglunbao2", "Fashitexiao_binglunbao1", "jiguang_shifa", "EpicZeus", "Fashitexiao_jiguang", "Fire2-1", "Effect_fashishifachuntexiao", "fireRainBase", "fengren1", "20001", "clawComboBase", "zhanshidaoguangtexiao1", "zhanshidaoguangtexiao2", "zhanshidaoguangtexiao3", "EffectSp", "zhanshi_putonggongji_mz"  };
    private string[] gongjianshou = { "buff_jiasu", "gongjianshou_fangun", "zhendangjiansi", "zhengdangjianshi_feixing", "Gongjianshou_sushe_shifa", "sushe_feixing", "jianyu_fashe", "arrowRainBase", "gong_pujian", "gong_pujian02", "Efx_CriticalStrike"  };

    void Start()
    {
        _instance=this;
    }
    public static ObjectPoolManager getIns()
    {
        return _instance;
    }
    

//    public void initMonsterPool()
//    {
//        foreach(string key in monsterNames)
//        {
//            GameObject gameobj1= ResoureManager.getIns().GetGameObjectByName("Prefab/Sprite/Monster/"+key);
//            _pooledGameObjects(key,gameobj1);
//        }
//    }
//
//
    public void dispose()
    {
        if(_pooledGameObjects ==null) return;
        foreach(string key in _pooledGameObjects.Keys)
        {
            GameObject.Destroy(_pooledGameObjects[key]);
        }
        _pooledGameObjects.Clear();
        _pooledGameObjects=null;
    }
}

