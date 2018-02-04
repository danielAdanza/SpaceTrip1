using UnityEngine;
using System.Collections;

public class model2 : MonoBehaviour {

	// Use this for initialization
	public float turnSpeed = 50f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (Vector3.up , turnSpeed * Time.deltaTime);
	}
}
