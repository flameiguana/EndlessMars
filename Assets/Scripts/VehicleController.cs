using UnityEngine;
using System.Collections;

public class VehicleController : MonoBehaviour {

	public float Speed;
	public float THRUST_FORCE = 30f;

	public bool ResetPos;


	public ParticleSystem leftThruster;
	public ParticleSystem rightThruster;
	public ParticleSystem topThurster;

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
	bool goDown = false;

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

		if(Input.GetButtonDown("Down")){
			goDown = true;
			topThurster.Play();
		}
		else if(Input.GetButtonUp("Down")){
			goDown = false;
			topThurster.Stop();
		}

		if(Input.GetButtonDown("Jump")){
			ApplyThrust(transform.up, THRUST_FORCE * 20f);
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
			ApplyThrust(transform.right * -1f, THRUST_FORCE);
		}
		
		if(goRight){
			ApplyThrust(transform.right, THRUST_FORCE);
		}

		if(goDown)
		{
			ApplyThrust(transform.up * -1f, THRUST_FORCE);
		}
		//Moves the body forward regardless of other factors.
		MoveForward();
	}


	//Applies a force. Adds up if button is held.
	private void ApplyThrust(Vector3 direction, float THRUST){
		rigidbody.AddForce(direction * THRUST);
	}

	private void MoveForward(){
		Vector3 desiredVelocity = rigidbody.velocity;
		desiredVelocity.z = Speed;
		rigidbody.velocity = desiredVelocity;
		//rigidbody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
	}
}
