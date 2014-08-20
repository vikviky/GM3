
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour {
	
	public LayerMask collisionMask; 
	
	private BoxCollider collider;
	private Vector3 s; // size
	private Vector3 c; // centre
	
	private float skin = .005f;
	
	[HideInInspector]
	public bool grounded;
	
	Ray ray;
	RaycastHit hit;
	
	void start() {
		collider = GetComponent <BoxCollider>();
		s = collider.size;
		c = collider.center; 
	}
	
	public void Move(Vector2 moveAmount) {
		
		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		Vector2 p = transform.position; // p = player
		
		for(int i = 0; i < 3; i++){
			float dir = Mathf.Sign(deltaY);
			float x = (p.x + c.x - s.x/2) + s.x/2*i; // left, centre and right side of collider 
			float y = p.y + c.y + s.y/2 * dir; // bottom of box collider 
			
			ray = new Ray(new Vector2(x,y), new Vector2 (0,dir));
			Debug.DrawRay(ray.origin, ray.direction);
			if (Physics.Raycast(ray,out hit,Mathf.Abs(deltaY),collisionMask)) {
				// dist between p and ground
				float dst = Vector3.Distance (ray.origin, hit.point);
				
				// stop p's downward movement when skin makes contact 
				if (dst>skin) {
					deltaY =  dst * dir + skin;
				}
				else {
					deltaY=0; 
				}
				grounded = true;
				break; 
			}
		} 
		
		Vector2 finalTransform = new Vector2 (deltaX, deltaY);
		
		transform.Translate(finalTransform); 
	}
}