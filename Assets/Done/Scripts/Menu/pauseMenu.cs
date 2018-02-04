using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {

	public Text pauseText;
	public GameObject button;
	public GameObject pausedObject;
	public GameObject background;

	public void onPauseClicked ()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;

			switch (PlayerData.playerData.languaje) 
			{
			  case 1:
				pauseText.text = "GAME PAUSED";
				break;
			  case 2:
				pauseText.text = "JUEGO EN PAUSA";
				break;
			  case 3:
				pauseText.text = "PAUZA";
				break;
			}
			background.SetActive (true);
			pausedObject.SetActive (true);

		}
		else
		{
			Time.timeScale = 1;
			pauseText.text = "";
			background.SetActive (false);
			pausedObject.SetActive (false);
		}
	}

	public void WhenExitIsClicked ()
	{
		Application.Quit ();
	}
}
