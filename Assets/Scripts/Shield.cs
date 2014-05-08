using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	bool shieldingPlayer = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			gameObject.transform.parent = collider.gameObject.transform;
			transform.localPosition = Vector3.zero;
			shieldingPlayer = true;
		}
		else if(shieldingPlayer && collider.tag == "Obstacle"){
			//Destroy obstacle and shield.
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}
}
