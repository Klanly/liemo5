using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDKEntry : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private static string getcurrPlat()
	{
		string plat=PlatName.MY;
		#if MY
		plat=PlatName.MY;
		#endif
		return plat;
	}

	public static void Oninit()
	{
		string platname=getcurrPlat();
		if(platname == PlatName.MY)
		{
			// LoginLogic.get
		}
	}
}
