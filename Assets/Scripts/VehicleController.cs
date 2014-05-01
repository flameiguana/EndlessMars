using UnityEngine;
using System.Collections;

public class VehicleController : MonoBehaviour {

	public float Speed;
	public float THRUST_FORCE;

	public bool ResetPos;


	public ParticleSystem leftThruster;
	public ParticleSystem rightThruster;

	Vector3 originalPos;
	Quaternion originalRotation;
	void Awake(){
		originalPos = transform.position;
		originalRotation = transform.rotation;
	}
	// Use this for initialization
	void Start () {
		//temp code
		renderer.material.color = Color.blue;
		rigidbody.velocity = transform.forward * Speed;
	}

	bool goLeft = false;
	bool goRight = false;

	// Update is called once per frame
	void Update () {
		//Change thruster state based on input.
		if(Input.GetButtonDown("Left")){
			goLeft = true; 
			//To go left use right thruster and vice versa
			rightThruster.Play();
		}
		else if(Input.GetButtonUp("Left")){
			goLeft = false;
			rightThruster.Stop();
		}
		if(Input.GetButtonDown("Right")){
			goRight = true;
			leftThruster.Play();
		}
		else if(Input.GetButtonUp("Right")){
			goRight = false;
			leftThruster.Stop();
		}

		if(Input.GetButtonDown("Jump")){
			JumpThrust();
		}

		if(ResetPos){
			if(transform.position.z > 60){
				transform.position = originalPos;
				transform.rotation = originalRotation;
			}
		}
	}

	void FixedUpdate()
	{

		//Note you can use both thrusters at once.
		if(goLeft){
			ApplyThrust(-1f);
		}
		
		if(goRight){
			ApplyThrust(1f);
		}
		//Moves the body forward regardless of other factors.
		MoveForward();
	}


	//Applies a force. Adds up if button is held.
	private void ApplyThrust(float direction){
		rigidbody.AddForce(transform.right * direction * THRUST_FORCE);
	}

	private void JumpThrust(){
		rigidbody.AddForce(Vector3.up * THRUST_FORCE * 20f);
	}



	private void MoveForward(){
		Vector3 desiredVelocity = rigidbody.velocity;
		desiredVelocity.z = Speed;
		rigidbody.velocity = desiredVelocity;
		//rigidbody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
	}
}
