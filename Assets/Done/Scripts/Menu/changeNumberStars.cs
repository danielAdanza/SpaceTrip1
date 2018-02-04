using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeNumberStars : MonoBehaviour {

	public Text stars;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		stars.text = "" + PlayerData.playerData.totalStarts;
	}
}
