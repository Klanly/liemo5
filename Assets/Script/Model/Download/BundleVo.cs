using UnityEngine;
using System.Collections;
using System.IO;

public class BundleVo
{
	public delegate void OnLoadBundleProgress (float progress);

	public delegate void OnLoadBundleComplete (BundleVo bundle);

	public delegate void OnLoadBundleError ();

	public event OnLoadBundleComplete OnComplete;
	public event OnLoadBundleProgress OnProgress;
	public event OnLoadBundleError OnError;

	public AssetBundle bundle = null;
	public bool isLoadDone = false;
	public string name;
	public int chunckSize;
	//大小
	public bool isLoadFromFile = false;
	private WWW www;
	public string nameWithVersion;

	public BundleVo (string nameWithVersion)
	{
		this.nameWithVersion = nameWithVersion;
	}

	public void StartDownload (OnLoadBundleComplete onCom_, OnLoadBundleProgress onProgress_, OnLoadBundleError onError_)
	{
		OnComplete += onCom_;
		OnProgress += onProgress_;
		OnError += onError_;
		CoroutineProxyManager.getIns ().StartCoroutineDelegate (DownloadAndCache);
	}

	IEnumerator DownloadAndCache ()
	{
		www = new WWW (Intro.Baseurl + name);
		Debug.Log ("BaseUrl=>" + Intro.Baseurl);
		yield return www;
		if (www.error == null && www.isDone) {
			string path = LMVersion.ASSET_BUNDLE_PATH + nameWithVersion;
			Debug.Log ("Path===>" + path);
			if (name.Contains (".assetbundle")) {
				File.WriteAllBytes (path, www.bytes);
			} else if (name.Contains (".zip")) {
				File.WriteAllBytes (path, www.bytes);
			} else {
				File.WriteAllBytes (path, www.bytes);
			}

			InvokeLoadComplete ();
		} else {

			InvokeLoadError ();
		}



	}

	private void InvokeLoadComplete ()
	{
		if (OnComplete != null) {
			OnComplete (this);
		}
	}

	private void InvokeLoadError ()
	{
		if (OnError != null) {
			OnError ();
		}
	}

	private void InvokeLoadProgress (float progress)
	{
		if (OnProgress != null) {
			OnProgress (progress);
		}
	}
}
