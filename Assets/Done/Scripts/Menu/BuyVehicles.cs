using UnityEngine;
using System.Collections;

public class BuyVehicles : MonoBehaviour 
{
	public GameObject buttonBuy1;
	public GameObject buttonBuy2;

	// Use this for initialization
	void Start () 
	{
		if (PlayerData.playerData.purchaseVehicle2 == 1) 
		{
			buttonBuy1.SetActive(false);
		}

		if (PlayerData.playerData.purchaseVehicle3 == 1) 
		{
			buttonBuy2.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BuyVehicle2 ()
	{
		if (PlayerData.playerData.totalStarts >= 30)
		{
			PlayerData.playerData.totalStarts = PlayerData.playerData.totalStarts - 30;
			PlayerData.playerData.purchaseVehicle2 = 1;
			PlayerData.playerData.Save ();
			buttonBuy1.SetActive(false);
		}
	}

	public void BuyVehicle3 ()
	{
		if (PlayerData.playerData.totalStarts >= 30)
		{
			PlayerData.playerData.totalStarts = PlayerData.playerData.totalStarts - 30;
			PlayerData.playerData.purchaseVehicle3 = 1;
			PlayerData.playerData.Save ();
			buttonBuy2.SetActive(false);
		}
	}
}
