using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadMainMenu : MonoBehaviour {

	public GameObject loadingImage;
	public Slider loadingBar;
	private AsyncOperation async;

	// Use this for initialization
	void Start () 
	{
		LoadScene (1);
	}

	public void LoadScene (int level)
	{
		loadingImage.SetActive (true);
		PlayerPrefs.SetInt ("level",level);
		StartCoroutine(LoadLevelWithBar(1));
	}
	
	IEnumerator LoadLevelWithBar (int level)
	{
		async = Application.LoadLevelAsync(level);
		while (!async.isDone)
		{
			loadingBar.value = async.progress;
			yield return null;
		}
	}
}
