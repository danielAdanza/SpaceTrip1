using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class languajeLevelMenu : MonoBehaviour {

	public Text p1;
	public Text b1;
	public Text b2;

	public GameObject planet;

	void Start () 
	{
		if (PlayerData.playerData.languaje == 2) 
		{
			changeToSpanish();
		}
		if (PlayerData.playerData.languaje == 3) 
		{
			changeToSlovene ();
		}
	}
	
	public void changeToSpanish ()
	{
		p1.text = "tierra";
		b1.text = "batalla";
		b2.text = "batalla";
	}

	public void changeToSlovene ()
	{
		p1.text = "zemlja";
		b1.text = "bitka";
		b2.text = "bitka";
	}
}
