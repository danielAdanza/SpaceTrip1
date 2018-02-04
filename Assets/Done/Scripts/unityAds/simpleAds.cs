using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class simpleAds : MonoBehaviour {

	[SerializeField] string gameID = "49974";

	void Awake () 
	{
		//true if we are in test mode
		Advertisement.Initialize (gameID, true);
	}

	public void ShowAd(string zone)
	{
		#if UNITY_EDITOR
		StartCoroutine(WaitForAd ());
		#endif
		
		if (string.Equals (zone, ""))
			zone = null;
		
		ShowOptions options = new ShowOptions ();
		options.resultCallback = AdCallbackhandler;
		
		if (Advertisement.isReady (zone))
			Advertisement.Show (zone, options);
	}

	void AdCallbackhandler (ShowResult result)
	{
		switch(result)
		{
		case ShowResult.Finished:
			Debug.Log ("Ad Finished. Rewarding player...");
			PlayerPrefs.SetInt ("revivir",1);
			Application.LoadLevel(Application.loadedLevel);
			break;
		case ShowResult.Skipped:
			Debug.Log ("Ad skipped. Son, I am dissapointed in you");
			break;
		case ShowResult.Failed:
			Debug.Log("I swear this has never happened to me before");
			break;
		}
	}

	IEnumerator WaitForAd()
	{
		float currentTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		yield return null;
		
		while (Advertisement.isShowing)
			yield return null;
		
		Time.timeScale = currentTimeScale;
	}
}
