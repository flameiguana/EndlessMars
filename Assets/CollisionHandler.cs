using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
	

	public bool shielded;
	Shield currentShield;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
	public void GiveShield(Shield shield){
		shield.transform.parent = transform;
		shield.transform.localPosition = Vector3.zero;
		currentShield = shield;
		shielded = true;
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Smashed");
        if (other.gameObject.tag == "Obstacle")
        {
            float xDistance = Mathf.Abs(transform.position.x - other.transform.position.x);
            float width = other.gameObject.renderer.bounds.size.x;

            //if (xDistance <= (width / 4.0f)) 
            //{

			EnvironmentManager.instance.obstacleList.Remove(other.gameObject);
			Destroy(other.gameObject);
			EnvironmentManager.instance.CreateObstacle();

			if(!shielded){
				Application.LoadLevel(Application.loadedLevel);
				Destroy(gameObject);
			}
			else {
				Destroy (currentShield.gameObject);
				shielded = false;
				currentShield = null;
			}
            //}
            //yield WaitForSeconds(5.0);
           

        }

    }
}
