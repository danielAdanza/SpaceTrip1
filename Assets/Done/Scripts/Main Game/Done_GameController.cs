using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	//level differences within the number of asteroids, the time distance within them and so on
	private int level;
	private int hazardCount;
	private float spawnWait;
	private float startWait;
	private float waveWait;
	private int numberWaves;
	private int maxscore;
	//interface objects
	public Text scoreText;
	public Text gameOverText;
	public Text levelText;
	public Text totalScoreText;
	//buttons
	public GameObject restartButton;
	public GameObject mainMenuButton;
	public GameObject nextLevelButton;
	public GameObject lifesButton;
	public GameObject shareButton;
	public GameObject backgroundImage;
	public RawImage star1;
	public RawImage star2;
	public RawImage star3;
	//variables for game over and score
	private bool gameOver;
	private int score;
	//for the different languajes
	string levelwin = "";
	string levelLoose = "";
	string total = "";
	
	void Start ()
	{
		level = PlayerPrefs.GetInt ("level");
		CreateLevelSettings (level);
		gameOver = false;
		gameOverText.text = "";
		totalScoreText.text = "";
		levelText.text = " : " + level;
		//score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());

		switch (PlayerData.playerData.languaje) 
		{
		case 1:
			levelwin = "level completed!";
			levelLoose = "game over";
			total = "total";
			break;
		case 2:
			levelwin = "!nivel completado!";
			levelLoose = "fin de la partida";
			total = "total";
			break;
		case 3:
			levelwin = "Stopnja končana!";
			levelLoose = "konec igre";
			total = "skupno";
			break;
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (numberWaves > 0)
		{
			numberWaves--;
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [CreateHazardLevel(level)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				backgroundImage.SetActive(true);
				gameOverText.color = Color.black;
				restartButton.SetActive(true);
				mainMenuButton.SetActive(true);
				lifesButton.SetActive(true);
				break;
			}
		}

		GameFinished ();
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "" + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = levelLoose;
		gameOver = true;
		PlayerData.playerData.totalmatches = PlayerData.playerData.totalmatches + 1;
		PlayerData.playerData.Save();
	}

	public void GameFinished ()
	{



		if (gameOver == false) {

			PlayerPrefs.SetInt ("revivir", 0);


			gameOverText.text = levelwin;
			backgroundImage.SetActive (true);
			gameOverText.color = Color.black;

			star1.gameObject.SetActive (true);
			star2.gameObject.SetActive (true);
			star3.gameObject.SetActive (true);
			if (score < maxscore * 3 / 10) {
				star1.color = Color.black;
				star1.CrossFadeAlpha (0.5f, 1f, true);
			} else {
				PlayerData.playerData.totalStarts = PlayerData.playerData.totalStarts + 1;
			}

			if (score < maxscore * 6 / 10) {
				star2.color = Color.black;
				star2.CrossFadeAlpha (0.5f, 1f, true);
			} else {
				PlayerData.playerData.totalStarts = PlayerData.playerData.totalStarts + 1;
			}

			if (score < maxscore * 9 / 10) {
				star3.color = Color.black;
				star3.CrossFadeAlpha (0.5f, 1f, true);
			} else {
				PlayerData.playerData.totalStarts = PlayerData.playerData.totalStarts + 1;
			}

			//actualizando los datos en el objeto playerData
			PlayerData.playerData.totalscore = PlayerData.playerData.totalscore + score;
			PlayerData.playerData.totalmatches = PlayerData.playerData.totalmatches + 1;
			PlayerData.playerData.totalvictories = PlayerData.playerData.totalvictories + 1;

			if (PlayerData.playerData.scoreinlevels [level - 1] < score) {
				PlayerData.playerData.scoreinlevels [level - 1] = score;
			}
			if (level == PlayerData.playerData.currentlevel) {
				PlayerData.playerData.currentlevel = PlayerData.playerData.currentlevel + 1;
			}
			PlayerData.playerData.Save ();


			totalScoreText.text = " + (" + score + ") " + total + " " + PlayerData.playerData.totalscore;
			mainMenuButton.SetActive (true);
			nextLevelButton.SetActive (true);
			shareButton.SetActive (true);
			//it is not necesary to transform the position any more
			//Vector3 temp = new Vector3(0,-30f,0);
			//mainMenuButton.transform.position += temp;
		}
		else 
		{
			//if it enters here the player have lost
			PlayerPrefs.SetInt ("score",score);
			PlayerPrefs.SetInt ("numberWaves",numberWaves);
		}

	}

	public void RestartGame () 
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void NextGame () 
	{
		PlayerPrefs.SetInt ("level",PlayerPrefs.GetInt ("level") + 1);
		Application.LoadLevel (Application.loadedLevel);
	}

	public void MainMenu () 
	{
		Application.LoadLevel ("MainMenu");
	}

	public void Share () 
	{
		if (FB.IsLoggedIn) 
		{
			FB.Feed (
				//the message that will appear in the facebook post
				linkCaption: "I passed the level" + level + " in SPACE TRIP! would you do it better?",
				//the link of the picture that has to be in the server
				picture: "https://fbcdn-photos-b-a.akamaihd.net/hphotos-ak-xpf1/t39.2081-0/p128x128/11057177_1578500015724414_820180295_n.png",
				//the text that they will see
				linkName: "Check it out",
				//that should be the link to google play
				link: "http://apps.facebook.com/" + FB.AppId + "/challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest")
				
				);
		}
		else 
		{
			FB.Login ("email,publish_actions", AuthCallback);
		}
	}

	void AuthCallback (FBResult result)
	{
		if (!FB.IsLoggedIn) 
		{
			Debug.Log ("the login did not work");
		}
	}

	void CreateLevelSettings (int level)
	{
		if (level < 10) 
		{
			startWait = 3f;			waveWait = 3f;
		} 
		else 
		{
			startWait = 2f;			waveWait = 2f;
		}

		switch (level)
		{
		case 1:
			hazardCount = 5;		numberWaves = 8;		spawnWait = 1f;
			maxscore = 320;
			break;
		case 2:
			hazardCount = 6;		numberWaves = 8;		spawnWait = 1f;
			maxscore = 432;
			break;
		case 3:
			hazardCount = 7;		numberWaves = 8;		spawnWait = 1f;
			maxscore = 560;
			break;
		case 4:
			hazardCount = 8;		numberWaves = 8;		spawnWait = 0.95f;
			maxscore = 520;
			break;
		case 5:
			hazardCount = 5;		numberWaves = 8;		spawnWait = 0.95f;
			maxscore = 600;
			break;
		case 6:
			hazardCount = 9;		numberWaves = 9;		spawnWait = 0.95f;
			maxscore = 666;
			break;
		case 7:
			hazardCount = 10;		numberWaves = 9;		spawnWait = 0.9f;
			maxscore = 738;
			break;
		case 8:
			hazardCount = 11;		numberWaves = 9;		spawnWait = 0.9f;
			maxscore = 810;
			break;
		case 9:
			hazardCount = 12;		numberWaves = 9;		spawnWait = 0.9f;
			maxscore = 882;
			break;
		case 10:
			hazardCount = 8;		numberWaves = 8;		spawnWait = 0.9f;
			maxscore = 960;
			break;
		//second world
		case 11:
			hazardCount = 10;		numberWaves = 10;		spawnWait = 0.85f;
			maxscore = 840;
			break;
		case 12:
			hazardCount = 11;		numberWaves = 10;		spawnWait = 0.85f;
			maxscore = 968;
			break;
		case 13:
			hazardCount = 12;		numberWaves = 10;		spawnWait = 0.85f;
			maxscore = 1020;
			break;
		case 14:
			hazardCount = 13;		numberWaves = 10;		spawnWait = 0.85f;
			maxscore = 1137;
			break;
		case 15:
			hazardCount = 6;		numberWaves = 10;		spawnWait = 0.85f;
			maxscore = 900;
			break;
		case 16:
			hazardCount = 14;		numberWaves = 11;		spawnWait = 0.8f;
			maxscore = 1310;
			break;
		case 17:
			hazardCount = 15;		numberWaves = 11;		spawnWait = 0.8f;
			maxscore = 1468;
			break;
		case 18:
			hazardCount = 16;		numberWaves = 11;		spawnWait = 0.8f;
			maxscore = 1566;
			break;
		case 19:
			hazardCount = 17;		numberWaves = 11;		spawnWait = 0.8f;
			maxscore = 1664;
			break;
		case 20:
			hazardCount = 9;		numberWaves = 12;		spawnWait = 0.8f;
			maxscore = 1620;
			break;
		
		}
		//mirando si ha revivido o no
		//0 no ha revivido y 1 si
		int survival = PlayerPrefs.GetInt ("revivir");
		if (survival == 1) 
		{
			score = PlayerPrefs.GetInt ("score");
			numberWaves = PlayerPrefs.GetInt ("numberWaves");
		} 
		else 
		{
			score = 0;
		}
	}
	
	int CreateHazardLevel (int level)
	{
		int random = Random.Range (0,11);
		int final = 0;
		int proLevel = 0; //processed level

		if (level < 10) 
		{
			proLevel = level;
		} 
		else if (level < 20) 
		{
			proLevel = level - 10;
		}
		switch (proLevel)
		{
		case 2:
			final = 1;
			break;
		case 3:
			final = 2;
			break;
		case 4:
			if (random > 7)
			{final = 1;}
			break;
		case 5:
			final = 3;
			break;
		case 6:
			if (random > 7)
			{final = 1;}
			break;
		case 7:
			if (random > 9)
			{final = 2;}
			else if (random > 7)
			{final = 1;}
			break;
		case 8:
			if (random > 8)
			{final = 2;}
			else if (random > 6)
			{final = 1;}
			break;
		case 9:
			if (random > 9)
			{final = 3;}
			else if (random > 8)
			{final = 2;}
			else if (random > 6)
			{final = 1;}
			break;
		case 10:
			final = 3;
			break;
		}
		
		return final;
	}
}