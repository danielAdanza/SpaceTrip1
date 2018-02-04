using UnityEngine;
using System.Collections;
//added for serialization
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData : MonoBehaviour {

	public static PlayerData playerData;
	//it includes the last world that the player has unlocked
	public int currentworld;
	//it includes the last level that the player has passed
	public int currentlevel;
	//the maximum score that the player has in each level
	public int[] scoreinlevels;
	//the total accumulative score that the player has
	public int totalscore;
	public int totalStarts;
	public int totalmatches;
	public int totalvictories;
	public int languaje;
	//vehicle things;
	//from 0 to 4 for the different selected skin
	public int vehicleTexture;
	// value float that goes till 0 to 1 and that will affect the final model shape
	public float vehicleThin;
	public float vehicleHeight;
	//the vehicle speed
	public int speed;
	public int vehicle;
	//each vehicle has 7 positions skins number 3, 4 and 5
	//and also velocity speed has four positions
	//each position will have 0 if it is not bought and
	public int[] purchases;
	public int purchaseVehicle2;
	public int purchaseVehicle3;

	void Awake () 
	{
		scoreinlevels = new int [40];
		purchases = new int [21];

		if (playerData == null) 
		{
			DontDestroyOnLoad (gameObject);
			playerData = this;
		} else 
		{
			Destroy(gameObject);
		}
		this.Load ();
	}

	//funciona con todo excepto con web
	public void Save ( )
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath +  "/playerdata.dat");

		Player player = new Player (playerData.currentworld,playerData.currentlevel,playerData.scoreinlevels,playerData.totalscore,playerData.totalStarts,playerData.totalmatches, playerData.totalvictories,playerData.languaje,playerData.vehicleTexture,
		                            playerData.vehicleThin,playerData.vehicleHeight,playerData.speed,playerData.vehicle,playerData.purchases,playerData.purchaseVehicle2,playerData.purchaseVehicle3);
		bf.Serialize (file,player);
		file.Close ();
	}

	public void Load ( )
	{
		if (File.Exists (Application.persistentDataPath + "/playerdata.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath +  "/playerdata.dat", FileMode.Open);
			Player player = (Player) bf.Deserialize(file);
			file.Close();

			playerData.currentworld = player.currentworld;
			playerData.currentlevel = player.currentlevel;
			playerData.scoreinlevels = player.scoreinlevels;
			playerData.totalscore = player.totalscore;
			playerData.totalStarts = player.totalStarts;
			playerData.totalmatches = player.totalmatches;
			playerData.totalvictories = player.totalvictories;
			playerData.languaje = player.languaje;
			playerData.vehicleTexture = player.vehicleTexture;
			playerData.vehicleThin = player.vehicleThin;
			playerData.vehicleHeight = player.vehicleHeight;
			playerData.speed = player.speed;
			playerData.vehicle = player.vehicle;
			playerData.purchases = player.purchases;
			playerData.purchaseVehicle2 = player.purchaseVehicle2;
			playerData.purchaseVehicle3 = player.purchaseVehicle3;
		}
	}

}

[Serializable]
class Player
{
	public Player (int currentworld, int currentlevel, int[] scoreinlevels, int totalscore, int totalStarts, int totalmatches, int totalvictories, int languaje, int vehicleTexture, float vehicleThin, float vehicleHeight, int speed, int vehicle, int [] purchases, int purchaseVehicle2, int purchaseVehicle3)
	{
		this.currentworld = currentworld;
		this.currentlevel = currentlevel;
		this.scoreinlevels = scoreinlevels;
		this.totalscore = totalscore;
		this.totalStarts = totalStarts;
		this.totalmatches = totalmatches;
		this.totalvictories = totalvictories;
		this.totalvictories = totalvictories;
		this.languaje = languaje;
		this.vehicleTexture = vehicleTexture;
		this.vehicleThin = vehicleThin;
		this.vehicleHeight = vehicleHeight;
		this.speed = speed;
		this.vehicle = vehicle;
		this.purchases = purchases;
		this.purchaseVehicle2 = purchaseVehicle2;
		this.purchaseVehicle3 = purchaseVehicle3;
	}
	
	public int currentworld;
	public int currentlevel;
	public int[] scoreinlevels;
	public int totalscore;
	public int totalStarts;
	public int totalmatches;
	public int totalvictories;
	public int languaje;
	public int vehicleTexture;
	public float vehicleThin;
	public float vehicleHeight;
	public int speed;
	public int vehicle;
	public int[] purchases;
	public int purchaseVehicle2;
	public int purchaseVehicle3;

}
