﻿using UnityEngine;
using System.Collections;

public class bossBattleEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("it entered here we will downgrade life!!");
	}
}
