using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class languajeMainGame : MonoBehaviour {

	public Text restart;
	public Text mainMenu;
	public Text nextLevel;
	public Text freeStar;
	public Text share;
	//pausemenu
	//public Text exit;
	public Text mainmenu;
	public Text goBack;


	// Use this for initialization
	void Start () 
	{
		if (PlayerData.playerData.languaje == 2) 
		{
			ChangeToSpanish();
		}
		if (PlayerData.playerData.languaje == 3) 
		{
			ChangeToSlovene ();
		}
	}
	
	public void ChangeToSpanish ()
	{
		restart.text = "volver a intentar";
		mainMenu.text = "menu principal";
		nextLevel.text = "siguiente nivel";
		freeStar.text = "1 vida gratis";
		share.text = "compartir";
		//exit.text = "salir";
		mainmenu.text = "menu principal";
		goBack.text = "jugar";
	}

	public void ChangeToSlovene ()
	{
		restart.text = "ponovno zaženi";
		mainMenu.text = "glavni meni";
		nextLevel.text = "naslednja stopnja";
		freeStar.text = "brezplačno življenje";
		share.text = "stol";
		mainmenu.text = "glavni meni";
		//exit.text = "izhod";
		goBack.text = "igraj";
	}
}
