using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class NoticeService : IService {

	private NotiveUICtr uiCtr;

	public NotiveUICtr UiCtr{
		get {return uiCtr;}
		set {uiCtr = value;}
	}

	public void init()
	{
		throw new System.NotImplementedException();
	}
	public void update()
	{
		throw new System.NotImplementedException();
	}
}
