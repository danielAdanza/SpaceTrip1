using UnityEngine;
using System.Collections;

public class EditVehicleMainGame : MonoBehaviour {

	public Texture[] myTextures = new Texture[5];
	public GameObject vehicle;

	void Start () 
	{
		vehicle.GetComponent<Renderer> ().material.mainTexture = myTextures [PlayerData.playerData.vehicleTexture];
	}

	void Update () {
	
	}
}
