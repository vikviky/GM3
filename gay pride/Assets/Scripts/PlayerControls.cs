using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerControls : MonoBehaviour {
	
	//Player Handling
	public float gravity = 20;
	public float speed = 8;
	public float acceleration = 30;
	public float jumpHeight = 12;
	public GameObject prefab;
	
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	private PlayerPhysics playerPhysics;
	
	void Start () {
		playerPhysics = GetComponent <PlayerPhysics> ();
	}
	
	void Update () {

		if(playerPhysics.movementStopped) {
			targetSpeed = 0;
			currentSpeed =0;
		
		}

		//Input 
		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		currentSpeed = incrementTowards (currentSpeed, targetSpeed, acceleration);

		if(playerPhysics.grounded) {
			amountToMove.y = 0;

			//Jump
			if(Input.GetButtonDown("Jump")) {
				amountToMove.y = jumpHeight;

			}
		}

		
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move (amountToMove * Time.deltaTime);
	}
	
	//Increasse n towards
	private float incrementTowards (float n, float target, float a) {
		if (n == target){
			return n; 
		}
		else { 
			float dir = Mathf.Sign (target - n);
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n))? n: target;
			
		}
	}
		void onCollisionEnter(Collider collider)
		{
			if (collider.gameObject.name == "Car") {
				Destroy(gameObject);}
		Debug.Log ("asdasd");
		}


}