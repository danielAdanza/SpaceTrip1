using UnityEngine;
using System.Collections;

public class simpleLoad : MonoBehaviour 
{
	public void loadScene (string name)
	{
		Application.LoadLevel (name); 
	}
}
