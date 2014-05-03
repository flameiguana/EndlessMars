using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour {

	public float HOVER_FORCE;
	public float HoverHeight;
	public float DampingFactor = .3f;
	int layerMask;

	void Start(){
		int layer = LayerMask.NameToLayer("Platform");
		layerMask = 1 << layer;
	}

	void FixedUpdate(){
		RaycastHit info;
		if(Physics.Raycast(transform.position, -Vector3.up, out info, HoverHeight, layerMask)){
			transform.up = info.normal;
			//The desired height - distance to floor. Should be positive
			float error = HoverHeight - info.distance;
			//Scale force by amount of error. The more we're off, the faster we want to get to our desired height
			float scaledForce = error * HOVER_FORCE; // kg/ms/s^2
			//To tone down bounciness, reduce force a little depending on direction.
			float currentDirection = rigidbody.velocity.y < 0 ? -1f : 1f;
			float smooth = currentDirection * scaledForce * DampingFactor;

			rigidbody.AddForce(Vector3.up * (scaledForce - smooth));
		}
	}
}
