using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public float carSpeed = 6000; 

	void Update () {
		transform.Rotate (Vector3.forward * carSpeed * Time.deltaTime, Space.World);
	
	}
}
