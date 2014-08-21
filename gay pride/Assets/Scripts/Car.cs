using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public float speed = 6000; 

	void Update () {
		gameObject.rigidbody2D.velocity = new Vector2(GameObject.FindWithTag("Player").rigidbody2D.velocity.x + speed,0.0f);
	}
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
// void on trigger
	void onTriggerEnter2d(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			Destroy(gameObject);}
	}
}
