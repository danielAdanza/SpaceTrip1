using UnityEngine;
using System.Collections;

public class ChangeMusic : MonoBehaviour {

	public AudioClip musicMenus;
	public AudioClip musicLevel;
	public AudioClip musicBattle1;
	public AudioClip musicBattle2;
	private AudioSource source;
	// Use this for initialization
	void Awake () 
	{
		source = GetComponent <AudioSource>();
	}

	void OnLevelWasLoaded (int scene) 
	{
		if (scene == 3) {
			int level = PlayerPrefs.GetInt ("level");
			if (level == 5) {
				source.clip = musicBattle1;
			} else if (level == 10) {
				source.clip = musicBattle2;
			} else {
				source.clip = musicLevel;
			}
			source.Play ();
		} else if (scene == 1) 
		{
			source.clip = musicMenus;
			source.Play ();
		}
	}
}
