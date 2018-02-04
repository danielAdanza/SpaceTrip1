using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguajeManagerVehicleSelection : MonoBehaviour 
{
	//buttons footer
	public Text backButton;
	public Text changeVehicleButton;
	//texto para las barritas
	public Text textshort;
	public Text texthight;
	public Text textwidth;
	public Text textheigth;
	public Text textspeed;
	//texto para comprar las skins
	public Text skindialog;
	public Text skinprice;
	//texto para comprar la velocidad
	//public Text speeddialog;
	//public Text speedprice;


	void Start () 
	{
		if (PlayerData.playerData.languaje == 2) 
		{
			changeToSpanish();
		}
		if (PlayerData.playerData.languaje == 3) 
		{
			changeToSlovene ();
		}
	}

	public void changeToSpanish ()
	{
		backButton.text = "volver";
		changeVehicleButton.text = "cambiar";
		textshort.text = "bajo";
		texthight.text = "alto";
		textwidth.text = "esbelto";
		textheigth.text = "ancho";
		textspeed.text = "veloc.";
		skindialog.text = "quieres comprar la skin seleccionada?";
		skinprice.text = "PRECIO: 10";
		//speeddialog.text = "quieres comprar mas velocidad?";
		//speedprice.text = "PRECIO: 20";
	}
	
	public void changeToSlovene ()
	{
		backButton.text = "volverk";
		changeVehicleButton.text = "cambiar";
		textshort.text = "bajo";
		texthight.text = "alto";
		textwidth.text = "alargado";
		textheigth.text = "ancho";
		textspeed.text = "velocidad";
		skindialog.text = "quieres comprar la skin seleccionada?";
		skinprice.text = "PRECIO: 10";
		//speeddialog.text = "quieres comprar mas velocidad?";
		//speedprice.text = "PRECIO: 20";
	}

}
