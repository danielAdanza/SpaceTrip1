using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter ()
	{
		Debug.Log ("collision");
	}

	void OntriggerEnter ()
	{
		Debug.Log ("triger");
	}

	void OntriggerExit ()
	{
		Debug.Log ("triger");
	}
}
