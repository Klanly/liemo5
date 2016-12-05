using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;

public class GetStringFromByte : MonoBehaviour {

	// Use this for initialization
	void Start () {
        byte[] contents=File.ReadAllBytes(Application.streamingAssetsPath+"/Pc/ResTextList.bytes");
        if(contents.Length>0){
            Debug.Log("OK"+ contents.Length);
            string str = System.Text.Encoding.Default.GetString ( contents );
            Debug.Log(str);
        }


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
