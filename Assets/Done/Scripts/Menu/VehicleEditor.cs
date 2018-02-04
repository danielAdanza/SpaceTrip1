using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VehicleEditor : MonoBehaviour {

	public Texture[] myTextures = new Texture[5];
	public GameObject vehicle;
	public Slider slider1;
	public Slider slider2;
	public Slider slider3;

	public GameObject purchasePopup;
	public GameObject objectVehicleInpurchase;
	public GameObject backButton;
	public GameObject changeVehicle;
	public GameObject vehiclePopup;

	//purchasepopup stuffs
	public GameObject v1;
	public GameObject v2;
	public GameObject v3;
	//purchase velocity
	public GameObject purchaseVelocity;



	void Start () 
	{

	}

	void Update () 
	{
		if (PlayerData.playerData.vehicle == 0) {
			vehicle.GetComponent<Renderer> ().material.mainTexture = myTextures [PlayerData.playerData.vehicleTexture];
		} else if (PlayerData.playerData.vehicle == 1) {
			//in an special script
		} else if (PlayerData.playerData.vehicle == 2) {
			vehicle.GetComponent<Renderer> ().material.mainTexture = myTextures [PlayerData.playerData.vehicleTexture];
			transform.localScale = new Vector3 (1f + slider2.value, slider1.value + 1f, 2f - slider2.value);
		}
	}

	public void ChangeVehicleSkeen (int num)
	{
		if (PlayerData.playerData.vehicle == 0) 
		{
			if (num == 0 || num == 1)
			{   PlayerData.playerData.vehicleTexture = num;   }
			else if (PlayerData.playerData.purchases[num - 2] == 1)
			{   PlayerData.playerData.vehicleTexture = num;   }
			else
			{
				PlayerPrefs.SetInt("skin",num - 2);
				backButton.SetActive(false);
				changeVehicle.SetActive(false);
				purchasePopup.SetActive(true);
				v1.SetActive(true);
				v2.SetActive(false);
				v3.SetActive(false);

			}
		}

		if (PlayerData.playerData.vehicle == 1) 
		{
			if (num == 0 || num == 1)
			{   PlayerData.playerData.vehicleTexture = num;   }
			else if (PlayerData.playerData.purchases[num + 5] == 1)
			{   PlayerData.playerData.vehicleTexture = num;   }
			else
			{
				PlayerPrefs.SetInt("skin",num + 5);
				backButton.SetActive(false);
				changeVehicle.SetActive(false);
				purchasePopup.SetActive(true);
				v1.SetActive(false);
				v2.SetActive(true);
				v3.SetActive(false);
			}
		}

		if (PlayerData.playerData.vehicle == 2) 
		{
			if (num == 0 || num == 1)
			{   PlayerData.playerData.vehicleTexture = num;   }
			else if (PlayerData.playerData.purchases[num + 12] == 1)
			{   PlayerData.playerData.vehicleTexture = num;   }
			else
			{
				PlayerPrefs.SetInt("skin",num + 12);
				backButton.SetActive(false);
				changeVehicle.SetActive(false);
				purchasePopup.SetActive(true);
				v1.SetActive(false);
				v2.SetActive(false);
				v3.SetActive(true);
			}
		}
	}

	public void ChangeShape ()
	{ 
		if (PlayerData.playerData.vehicle == 0) 
		{
			vehicle.transform.localScale = new Vector3 (0.7f + slider2.value, slider1.value + 1.5f, 3.1f - slider2.value);
			PlayerData.playerData.vehicleThin = slider2.value;
			PlayerData.playerData.vehicleHeight = slider1.value;
		} 
		else if (PlayerData.playerData.vehicle == 1) 
		{
			vehicle.transform.localScale = new Vector3 (35.0f + (slider2.value*10.0f), (slider1.value*10.0f) + 35.0f, 45.0f - (slider2.value*10) );
			PlayerData.playerData.vehicleThin = slider2.value;
			PlayerData.playerData.vehicleHeight = slider1.value;
		}
		else if (PlayerData.playerData.vehicle == 2) 
		{
			vehicle.transform.localScale = new Vector3 (1.5f + slider2.value, slider1.value + 1.5f, 2.5f - slider2.value);
			PlayerData.playerData.vehicleThin = slider2.value;
			PlayerData.playerData.vehicleHeight = slider1.value;
		}
	}

	public void changePlusVelocity ()
	{
		//si la velocidad es menor que dos , no hay problema siempre sube
		if (PlayerData.playerData.speed < 1) 
		{
			PlayerData.playerData.speed = PlayerData.playerData.speed + 1;
			slider3.value = slider3.value + 0.2f;
		} 
		//si no entonces mirar que no pase el limite maximo
		else if (PlayerData.playerData.speed < 5) 
		{
			if (PlayerData.playerData.vehicle == 0)
			{
				if (PlayerData.playerData.purchases[PlayerData.playerData.speed+2] == 0)
				{
					PlayerPrefs.SetInt("skin",PlayerData.playerData.speed+2);
					purchaseVelocity.SetActive(true);
				}
				else
				{
					PlayerData.playerData.speed = PlayerData.playerData.speed + 1;
					slider3.value = slider3.value + 0.2f;
				}
			}
			else if (PlayerData.playerData.vehicle == 1)
			{
				if (PlayerData.playerData.purchases[PlayerData.playerData.speed+9] == 0)
				{
					PlayerPrefs.SetInt("skin",PlayerData.playerData.speed+9);
					purchaseVelocity.SetActive(true);
				}
				else
				{
					PlayerData.playerData.speed = PlayerData.playerData.speed + 1;
					slider3.value = slider3.value + 0.2f;
				}
			}
			else if (PlayerData.playerData.vehicle == 2)
			{
				if (PlayerData.playerData.purchases[PlayerData.playerData.speed+16] == 0)
				{
					PlayerPrefs.SetInt("skin",PlayerData.playerData.speed+16);
					purchaseVelocity.SetActive(true);
				}
				else
				{
					PlayerData.playerData.speed = PlayerData.playerData.speed + 1;
					slider3.value = slider3.value + 0.2f;
				}
			}
		}
	}

	public void changeMinusVelocity ()
	{
		if (PlayerData.playerData.speed > 0) 
		{
			PlayerData.playerData.speed = PlayerData.playerData.speed - 1;
			slider3.value = slider3.value - 0.2f;
		}
	}

	public void noclicked ()
	{
		backButton.SetActive(true);
		changeVehicle.SetActive(true);
		purchasePopup.SetActive (false);
	}

	public void noclickedVelocity ()
	{
		backButton.SetActive(true);
		changeVehicle.SetActive(true);
		purchaseVelocity.SetActive (false);
	}

	public void yesclicked ()
	{
		if (PlayerData.playerData.totalStarts > 10) 
		{
			PlayerData.playerData.purchases [PlayerPrefs.GetInt ("skin")] = 1;
			PlayerData.playerData.totalStarts = PlayerData.playerData.totalStarts - 10;
			purchasePopup.SetActive(false);
			backButton.SetActive(true);
			changeVehicle.SetActive(true);
		}
	}

	public void yesclickedVelocity ()
	{
		if (PlayerData.playerData.totalStarts > 20) 
		{
			PlayerData.playerData.purchases [PlayerPrefs.GetInt ("skin")] = 1;
			PlayerData.playerData.totalStarts = PlayerData.playerData.totalStarts - 20;
			purchaseVelocity.SetActive(false);
			backButton.SetActive(true);
			changeVehicle.SetActive(true);
		}
	}

}
