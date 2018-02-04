using UnityEngine;
using System.Collections;

public class model : MonoBehaviour {

	// Use this for initialization
	public float turnSpeed = 50f;

	void Start () 
	{
	}

	void Update ()
	{
		transform.Rotate (Vector3.forward , turnSpeed * Time.deltaTime);
	}
}
