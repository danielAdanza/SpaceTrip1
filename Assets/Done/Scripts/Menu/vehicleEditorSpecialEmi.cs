using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class vehicleEditorSpecialEmi : MonoBehaviour {

	public Texture[] myTextures = new Texture[5];
	public GameObject vehicleSkin;
	public Slider slider1;
	public Slider slider2;
	public Slider slider3;

	// Update is called once per frame
	void Update () 
	{
		vehicleSkin.GetComponent<Renderer> ().material.mainTexture = myTextures [PlayerData.playerData.vehicleTexture];
	}
}
