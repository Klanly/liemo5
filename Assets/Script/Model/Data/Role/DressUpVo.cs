using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;


public class DressUpVo {
    public int clothesID=0;
    public int clothes_strong=0;
    public int equipID = 0;
    public int equip_strong=0;
    public int wingID=0;
    public int wing_strong=0;

    private string dressUp;

    public string DressUp{
        get{return dressUp;}
        set {dressUp=value;
            clothesID=Int32.Parse(getDressUpInfo()[0]);
            equipID=Int32.Parse(getDressUpInfo()[1]);
            equip_strong=Int32.Parse(getDressUpInfo()[2]);
            }
    }
    public int type;
    public void setDressUp(ByteData data)
    {
        clothesID = data.readInt();
        clothes_strong=data.readInt();
        equipID= data.readInt();
        wingID=data.readInt();
        wing_strong=data.readInt();
    }

    private string[] getDressUpInfo()
    {
        if(StringUtil.isNull(dressUp))
        {
            dressUp = "0_0_0_0";
        }
        return dressUp.Split('_');
    }

}