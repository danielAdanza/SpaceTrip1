using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	//retoque por mi
	public GameObject spaceship;
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	private Quaternion calibrationQuaternion;

	void Start ()
	{
		CalibrateAccelerometer ();
		speed = speed + (PlayerData.playerData.speed * 10);
	}
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{
		//moving with computer or web
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");
		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		//moving with phones
		Vector3 accelerationRaw = Input.acceleration;
		Vector3 acceleration = FixAcceleration (accelerationRaw);
		Vector3 movement = new Vector3 (acceleration.x, 0.0f, acceleration.y);

		spaceship.GetComponent<Rigidbody>().velocity = movement * speed;
		
		spaceship.GetComponent<Rigidbody>().position = new Vector3
		(
				Mathf.Clamp (spaceship.GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
				Mathf.Clamp (spaceship.GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		spaceship.GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	//Used to calibrate the Iput.acceleration input
	void CalibrateAccelerometer () 
	{
		Vector3 accelerationSnapshot = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation (new Vector3 (0.0f, 0.0f, -1.0f), accelerationSnapshot);
		calibrationQuaternion = Quaternion.Inverse (rotateQuaternion);
	}
	
	//Get the 'calibrated' value from the Input
	Vector3 FixAcceleration (Vector3 acceleration) 
	{
		Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
		return fixedAcceleration;
	}

}
