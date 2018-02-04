using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

	public Texture[] myTextures = new Texture[6];
	public Texture[] myTextures2 = new Texture[6];
	public GameObject background1;
	public GameObject background2;
	public GameObject planet;
	private int level;

	void Start () 
	{
		level = PlayerPrefs.GetInt ("level");

		if (level < 11) 
		{
			background1.GetComponent<Renderer> ().material.mainTexture = myTextures [0];
			background2.GetComponent<Renderer> ().material.mainTexture = myTextures [0];

			planet.GetComponent<Renderer> ().material.mainTexture = myTextures2 [0];
		} 
		if ( (level > 10) && (level < 21) )
		{
			background1.GetComponent<Renderer> ().material.mainTexture = myTextures [1];
			background2.GetComponent<Renderer> ().material.mainTexture = myTextures [1];

			planet.GetComponent<Renderer> ().material.mainTexture = myTextures2 [1];
		} 
		if ( (level > 20) && (level < 31) ) 
		{
			background1.GetComponent<Renderer> ().material.mainTexture = myTextures [2];
			background2.GetComponent<Renderer> ().material.mainTexture = myTextures [2];

			planet.GetComponent<Renderer> ().material.mainTexture = myTextures2 [2];
		}

	}

	void Update () 
	{

	}
}
