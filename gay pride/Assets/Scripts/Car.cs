using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public float speed = 6000; 

	void Update () {
			}
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
// void on trigger
	void onCollisionEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player(Clone)") {
			Destroy(gameObject);}
	}
}
