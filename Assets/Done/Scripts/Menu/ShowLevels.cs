using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowLevels : MonoBehaviour {

	//worlds
	public GameObject w1;
	public GameObject w2;
	//title & Planets
	public Text title;
	public GameObject planetw1;
	public GameObject planetw2;
	//levels
	public GameObject l2;
	public GameObject l3;
	public GameObject l4;
	public GameObject l5;
	public GameObject l6;
	public GameObject l7;
	public GameObject l8;
	public GameObject l9;
	public GameObject l10;
	public GameObject next;

	void Start () 
	{
		//Handheld.PlayFullScreenMovie ("ST VIDEO HISTORIA 1_0001.mp4",Color.black,FullScreenMovieControlMode.CancelOnInput);
		Handheld.PlayFullScreenMovie ("ST VIDEO HISTORIA 1_0001.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
		LevelsW1 ();
	}

	void LevelsW1 ()
	{
		int level = PlayerData.playerData.currentlevel;
		
		if (level < 2) 
		{
			l2.SetActive (false);
		}
		if (level < 3)
		{
			l3.SetActive (false);
		}
		if (level < 4)
		{
			l4.SetActive (false);
		}
		if (level < 5)
		{
			l5.SetActive (false);
		}
		if (level < 6)
		{
			l6.SetActive (false);
		}
		if (level < 7)
		{
			l7.SetActive (false);
		}
		if (level < 8)
		{
			l8.SetActive (false);
		}
		if (level < 9)
		{
			l9.SetActive (false);
		}
		if (level < 10)
		{
			l10.SetActive (false);
			next.SetActive (false);
		}
	}

	public void ChangeToW1 ()
	{
		w1.SetActive (true);
		w2.SetActive (false);
		planetw1.SetActive (true);
		planetw2.SetActive (false);
		switch (PlayerData.playerData.languaje) 
		{
			case 1:
			title.text = "earth";
			break;
			case 2:
			title.text = "tierra";
			break;
			case 3:
			title.text = "zemlja";
			break;
		}

	}

	public void ChangeToW2 ()
	{
		w1.SetActive (false);
		w2.SetActive (true);
		planetw1.SetActive (false);
		planetw2.SetActive (true);

		switch (PlayerData.playerData.languaje) 
		{
		case 1:
			title.text = "mars";
			break;
		case 2:
			title.text = "marte";
			break;
		case 3:
			title.text = "mars";
			break;
		}
	}
}
