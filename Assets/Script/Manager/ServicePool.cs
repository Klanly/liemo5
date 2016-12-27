using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePool {
	private static ServicePool _ins;
	private Dictionary<ServiceIndex,IService> _services= new Dictionary<ServiceIndex,IService>();


	public enum ServiceIndex
	{
		ROLE_SERVICE, //角色相关
        SCENE_SERVICE, //场景先关
        BATTLE_SERVICE, //战斗相关
        PACK_SERVICE, //背包相关
		ITEMINFO,//装备详情
        EQUIPLIST,//装备相关
        MAINUISERVICE,//主界面数据
        CLEARANCE,//通关结算
        TASK,//任务界面相关
        FUBEN,//副本界面相关
        SHOP,//商店界面相关
        GEM,//宝石界面相关
        STRENG,//强化界面相关
        GUIDE,//新手引导界面相关
        SKILL,//技能界面相关
        CHAT,//聊天界面
        FACTION,//帮派界面
        DRAWLUCK,//抽奖界面
        RANK,//排行榜
        Pet,
        SIGNIN,//签到
        ACTIVITY,//活动副本
        ROLEATTR,//人物属性
		INFORMATION,
        Mail,//邮箱
        FirstFight,//首站
        EQUIPACCESS,//物品来源
        REVIVE,//复活面板
        WORLDBOSSUI,//世界boss
        VIP,//vip
        NOTIVE,//公告
        PLAYERINFO,//角色信息界面
        ALLRANK,//总排行榜界面相关
        //GirlGetAward//女神奖励
        EXCHANGE,//兑换
        ALLACTIVITY,//总活动界面
        CLAN, //公会
        ALLGOD,//团战竞技场UI
        WEEKTASK,//七日任务UI
        ARENA,//竞技场UI
		SEVENSIGN,
		_NEWACT,
		LEVELUP,
		SETUPUI,
		MolManager,
	}

	public static ServicePool getIns()
	{
		if(_ins == null){
			_ins=new ServicePool();
			_ins.init();
		}
		return _ins;
	}

	public void init()
	{

	}
	private void addService(ServiceIndex index, IService service)
	{
		_services[index]= service ;
	}

	public NoticeService getNotice()
	{
		return _services[ServiceIndex.NOTIVE] as NoticeService;
	}
}
