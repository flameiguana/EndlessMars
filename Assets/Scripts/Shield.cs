﻿using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public AudioSource powerUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			collider.gameObject.GetComponent<CollisionHandler>().GiveShield(this);
            powerUp.Play();
		}
	}
}
