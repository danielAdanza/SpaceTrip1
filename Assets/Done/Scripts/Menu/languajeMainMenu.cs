using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class languajeMainMenu : MonoBehaviour 
{
	public Text scores;
	public Text invite;
	public Text achievements;
	public Text play;
	public Text editVehicle;
	public Text settings;
	public Text getFreeStars;
	public Text credits;
	public Text playerInfo;
	public Text languajes;
	//credits section
	public Text companyProducer;
	public Text director;
	public Text vehicleModeler;
	public Text baseGame;
	public Text music;
	//player data section
	public Text level1;
	public Text level2;
	public Text score;
	public Text matches;
	public Text stars;
	public Text victories;

	public GameObject background;
	public GameObject languajesSection;

	//0 = not set
	//1 = english
	//2 = spanish;
	//3 = slovene;
	void Start () 
	{
		if (PlayerData.playerData.languaje == 0) 
		{
			PlayerPrefs.SetInt ("mode",3);
			background.SetActive(true);
			languajesSection.SetActive(true);
		}

		if (PlayerData.playerData.languaje == 1) 
		{
			level1.text = "current level:";
			level2.text = PlayerData.playerData.currentworld + " - " + PlayerData.playerData.currentlevel;
			score.text = "score: " + PlayerData.playerData.totalscore;
			matches.text = "matches: " + PlayerData.playerData.totalmatches;
			stars.text = "stars: " + PlayerData.playerData.totalStarts;
			victories.text = "victories: " + PlayerData.playerData.totalvictories * 100 / PlayerData.playerData.totalmatches + " % ";
		}

		if (PlayerData.playerData.languaje == 2) 
		{
			changeToSpanish();
			level1.text = "nivel actual:";
			level2.text = PlayerData.playerData.currentworld + " - " + PlayerData.playerData.currentlevel;
			score.text = "Puntuacion: "+ PlayerData.playerData.totalscore;
			matches.text = "partidas: " + PlayerData.playerData.totalmatches;
			stars.text = "estrellas: "+ PlayerData.playerData.totalStarts;
			victories.text = "victorias: "+ PlayerData.playerData.totalvictories * 100 / PlayerData.playerData.totalmatches + " % ";		}

		if (PlayerData.playerData.languaje == 3) 
		{
			changeToSlovene ();
			level1.text = "trenutna raven:";
			level2.text = PlayerData.playerData.currentworld + " - " + PlayerData.playerData.currentlevel;
			score.text = "ocena: "+ PlayerData.playerData.totalscore;
			matches.text = "tekme: " + PlayerData.playerData.totalmatches;
			stars.text = "zvezde: "+ PlayerData.playerData.totalStarts;
			victories.text = "zmage: "+ PlayerData.playerData.totalvictories * 100 / PlayerData.playerData.totalmatches + " % ";
		}


	}

	public void changeToEnglish ()
	{
		PlayerData.playerData.languaje = 1;
		PlayerData.playerData.Save();
		
		scores.text = "scores";
		invite.text = "invite";
		achievements.text = "achievements";
		play.text = "play";
		editVehicle.text = "Edit Vehicle";
		settings.text = "options";
		getFreeStars.text = "get free stars";
		credits.text = "credits";
		playerInfo.text = "player info";
		languajes.text = "languajes";

		companyProducer.text = "company producer:";
		director.text = "director & programmer:";
		vehicleModeler.text = "Vehicle designer:";
		baseGame.text = "base game:";
		music.text = "music producer:";
		level1.text = "current level:";
		level2.text = PlayerData.playerData.currentworld + " - " + PlayerData.playerData.currentlevel;
		score.text = "score: "+ PlayerData.playerData.totalscore;
		matches.text = "matches: " + PlayerData.playerData.totalmatches;
		stars.text = "stars: "+ PlayerData.playerData.totalStarts;
		victories.text = "victories: "+ PlayerData.playerData.totalvictories * 100 / PlayerData.playerData.totalmatches + " % ";
		
	}

	public void changeToSpanish ()
	{
		PlayerData.playerData.languaje = 2;
		PlayerData.playerData.Save();

		scores.text = "ranking";
		invite.text = "invitar";
		achievements.text = "logros";
		play.text = "jugar";
		editVehicle.text = "Editar Vehículo";
		settings.text = "opciones";
		getFreeStars.text = "Estrellas gratis";
		credits.text = "créditos";
		playerInfo.text = "datos del jugador";
		languajes.text = "idiomas";
		companyProducer.text = "empresa productora:";
		director.text = "director y programador:";
		vehicleModeler.text = "diseñadores de vehiculo:";
		baseGame.text = "base del juego:";
		music.text = "productor musical:";

		level1.text = "nivel actual:";
		level2.text = PlayerData.playerData.currentworld + " - " + PlayerData.playerData.currentlevel;
		score.text = "Puntuacion: "+ PlayerData.playerData.totalscore;
		matches.text = "partidas: " + PlayerData.playerData.totalmatches;
		stars.text = "estrellas: "+ PlayerData.playerData.totalStarts;
		victories.text = "victorias: "+ PlayerData.playerData.totalvictories * 100 / PlayerData.playerData.totalmatches + " % ";


	}

	public void changeToSlovene ()
	{
		PlayerData.playerData.languaje = 3;
		PlayerData.playerData.Save();
		
		scores.text = "rezultati";
		invite.text = "povabi";
		achievements.text = "dosežki";
		play.text = "igra";
		editVehicle.text = "spremeni vozilo";
		settings.text = "možnosti";
		getFreeStars.text = "brezplačne zvezde";
		credits.text = "krediti";
		playerInfo.text = "podatki o igralcu";
		languajes.text = "jeziki";
		companyProducer.text = "razvijalec:";
		director.text = "vodja in programer:";
		vehicleModeler.text = "oblikovalec vozil:";
		baseGame.text = "osnova igre:";
		music.text = "glasbeni producent:";

		level1.text = "trenutna raven:";
		level2.text = PlayerData.playerData.currentworld + " - " + PlayerData.playerData.currentlevel;
		score.text = "ocena: "+ PlayerData.playerData.totalscore;
		matches.text = "tekme: " + PlayerData.playerData.totalmatches;
		stars.text = "zvezde: "+ PlayerData.playerData.totalStarts;
		victories.text = "zmage: "+ PlayerData.playerData.totalvictories * 100 / PlayerData.playerData.totalmatches + " % ";
		
	}

}
