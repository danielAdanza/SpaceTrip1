using UnityEngine;
using System.Collections;

public class vehicleSelectorMainGame : MonoBehaviour {

	public GameObject vehicle1;
	public GameObject vehicle2;
	public GameObject vehicle3;
	void Start () 
	{
		if (PlayerData.playerData.vehicle == 0) {
			vehicle1.SetActive (true);
			vehicle1.transform.localScale = new Vector3 (0.7f + (PlayerData.playerData.vehicleThin / 2), (PlayerData.playerData.vehicleHeight/2) + 1f, 1.5f - (PlayerData.playerData.vehicleThin/2) );
		} else if (PlayerData.playerData.vehicle == 1) {
			vehicle3.SetActive (true);

		} else if (PlayerData.playerData.vehicle == 2) {
			vehicle2.SetActive (true);
			vehicle2.transform.localScale = new Vector3 (0.5f + (PlayerData.playerData.vehicleThin / 2), (PlayerData.playerData.vehicleHeight/2) + 0.5f, 1f - (PlayerData.playerData.vehicleThin/2) );
		}

	}
}
