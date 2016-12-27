using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginLogic : MonoBehaviour {

	public LoginWindowCtr loginctr;
	public RegisterWindowctr registerCtr;
	public CreatRoleWindowCtr creatRole;
	public EnterGameWindowCtr enterGame;
	public ServerChooseWinCtr serverChooseEnter;
	public NotiveUICtr notive;
	public GameObject AwtScene;
	public HttpServerManager http;
	public const string  remoteIp="192.168.1.150";
	public const string  MD5="d7986317bc300fda92afba602ca7f8bf";
	public const string  Seid ="1";
	public const string  packageID="1234";
	public const string  appid ="13";
	public const string  token= "token";
	public const string  exinfo="exinfo";
	public const string typePlat="typePlat";


	// Use this for initialization
	void Start () {
		//cleanChatCache();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setAwt_SceneStatus(bool boo ,RoleVo vo=null)
	{
		
	}
}
