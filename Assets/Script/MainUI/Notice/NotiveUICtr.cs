using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotiveUICtr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		ServicePool.getIns().getNotice().UiCtr=this;
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void Finished()
	{
		this.gameObject.SetActive(false);
	}

	public void Ok_Btn_click()
	{
		Finished();
		Invoke("SdkEntry",0.2f);
	}
	private void SdkEntry(){
		SDKEntry.Oninit();
	}
}
