using UnityEngine;
using System.Collections;

public class GoToScene : MonoBehaviour {

	public GameObject settingsSection;
	public GameObject languajesSection;
	public GameObject creditsSection;
	public GameObject playerDataSection;
	public GameObject background;
	
	public void changeScene ()
	{
		Application.LoadLevel (2);
	}

	public void changeSceneEditVehicle ()
	{
		Application.LoadLevel (4);
	}

	//mode 0 menu principal
	//mode 1 friends score
	//mode 2 settings
	//mode 3 languajes
	//mode 4 credits
	//mode 5 player Data

	public void goToSettings ()
	{
		PlayerPrefs.SetInt ("mode",2);
		background.SetActive (true);
		settingsSection.SetActive (true);
	}

	public void goToLanguajes ()
	{
		PlayerPrefs.SetInt ("mode",3);
		languajesSection.SetActive (true);
		settingsSection.SetActive (false);
	}

	public void goToCredits ()
	{
		PlayerPrefs.SetInt ("mode",4);
		creditsSection.SetActive (true);
		settingsSection.SetActive (false);
	}

	public void goToPlayerData ()
	{
		PlayerPrefs.SetInt ("mode",5);
		playerDataSection.SetActive (true);
		settingsSection.SetActive (false);
	}
}
