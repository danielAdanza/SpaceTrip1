using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour 
{
	public GameObject loadingImage;
	public Slider loadingBar;
	private AsyncOperation async;
	public GameObject instructionsObject;

	public void LoadScene (int level)
	{
		loadingImage.SetActive (true);
		PlayerPrefs.SetInt ("level",level);
		PlayerPrefs.SetInt ("revivir",0);
		StartCoroutine(LoadLevelWithBar(3));
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

	public void LoadInstructions ()
	{
		instructionsObject.SetActive (true);
	}
}
