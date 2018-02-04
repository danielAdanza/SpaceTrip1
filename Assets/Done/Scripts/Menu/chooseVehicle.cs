using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class chooseVehicle : MonoBehaviour {

	public GameObject v0;
	public GameObject v1;
	public GameObject v2;

	public GameObject backgroundPop;
	public GameObject vehicleObject;

	public Text skin3;
	public Text skin4;
	public Text skin5;

	//2 game objects that are the sliders again
	public GameObject slider1again;
	public GameObject slider2again;

	public void ChooseVehicle (int vehicle)
	{
		if (vehicle == 0) 
		{
			backgroundPop.SetActive (false);
			vehicleObject.SetActive (false);

			PlayerData.playerData.vehicle = vehicle;
			PlayerData.playerData.vehicleTexture = 0;
			PlayerData.playerData.speed = 0;

			//activating and disactivating the sliders
			slider1again.SetActive(true);
			slider2again.SetActive(true);
		} else if ( (vehicle == 1) && ( PlayerData.playerData.purchaseVehicle2 == 1 ) )
		{
			backgroundPop.SetActive (false);
			vehicleObject.SetActive (false);
			
			PlayerData.playerData.vehicle = vehicle;
			PlayerData.playerData.vehicleTexture = 0;
			PlayerData.playerData.speed = 0;

			//activating and disactivating the sliders
			slider1again.SetActive(false);
			slider2again.SetActive(false);
		}else if ( (vehicle == 2) && ( PlayerData.playerData.purchaseVehicle3 == 1 ) )
		{
			backgroundPop.SetActive (false);
			vehicleObject.SetActive (false);
			
			PlayerData.playerData.vehicle = vehicle;
			PlayerData.playerData.vehicleTexture = 0;
			PlayerData.playerData.speed = 0;

			//activating and disactivating the sliders
			slider1again.SetActive(true);
			slider2again.SetActive(true);
		}

		if (vehicle == 0) 
		{
			v0.SetActive(true);

			if (PlayerData.playerData.purchases[0]== 0)
			{skin3.text = "X";}
			else
			{skin3.text = "3";}

			if (PlayerData.playerData.purchases[1]== 0)
			{skin4.text = "X";}
			else
			{skin4.text = "4";}

			if (PlayerData.playerData.purchases[2]== 0)
			{skin5.text = "X";}
			else
			{skin5.text = "5";}
		} 
		else if(vehicle == 1) 
		{
			if ( PlayerData.playerData.purchaseVehicle2 == 1 )
			{
				v1.SetActive(true);

				if (PlayerData.playerData.purchases[7]== 0)
				{skin3.text = "X";}
				else
				{skin3.text = "3";}
				
				if (PlayerData.playerData.purchases[8]== 0)
				{skin4.text = "X";}
				else
				{skin4.text = "4";}
				
				if (PlayerData.playerData.purchases[9]== 0)
				{skin5.text = "X";}
				else
				{skin5.text = "5";}
			}
		} 
		else if(vehicle == 2) 
		{
			if ( PlayerData.playerData.purchaseVehicle3 == 1 )
			{
				v2.SetActive(true);

				if (PlayerData.playerData.purchases[14]== 0)
				{skin3.text = "X";}
				else
				{skin3.text = "3";}
				
				if (PlayerData.playerData.purchases[15]== 0)
				{skin4.text = "X";}
				else
				{skin4.text = "4";}
				
				if (PlayerData.playerData.purchases[16]== 0)
				{skin5.text = "X";}
				else
				{skin5.text = "5";}
			}
		}
	}

	public void changeVehicle ()
	{
		v0.SetActive(false);
		v1.SetActive(false);
		v2.SetActive(false);
		backgroundPop.SetActive (true);
		vehicleObject.SetActive (true);
	}

	public void backFunction ()
	{
		PlayerData.playerData.Save ();
		Application.LoadLevel (1); 
	}
}
