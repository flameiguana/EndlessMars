using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
	public bool shielded;
	Shield currentShield;
    public GameObject explosion;
    public AudioSource shieldPowerDown;

	int shieldCount = 0;

	Color[] colors = new Color[3];

	void Awake(){

		colors[0] = new Color(255f/255f, 255f/255f, 255f/255f);
		colors[1] = new Color(37f/255f, 147f/255f, 221f/255f);
		colors[2] = new Color(16f/255f, 0f/255f, 255f/255f);


	}

	public void GiveShield(Shield shield){
        if (!shielded)
        {
            shield.transform.parent = transform;
            shield.transform.localPosition = Vector3.zero;
            currentShield = shield;
            shielded = true;
			shieldCount++;
        }
        else
        {
			Destroy(shield);
			if(shieldCount < 3){
				shieldCount++;
				currentShield.renderer.material.SetColor("_Color", colors[shieldCount - 1]);
			}
        }
	}

	void CollisionHandle(){
		if(!shielded){
			if(onDeath != null){
                GameObject currentExplosion = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
				onDeath(gameObject);
			}
		}
		else {
			shieldPowerDown.Play();	
			shieldCount--;

			if(shieldCount == 0){
				Destroy (currentShield.gameObject);
				shielded = false;
				currentShield = null;
			}
			else {
				currentShield.renderer.material.SetColor("_Color", colors[shieldCount - 1]);
			}

		}
	}

	public delegate void DieAction(GameObject gameObject);
	public static event DieAction onDeath;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            float xDistance = Mathf.Abs(transform.position.x - other.transform.position.x);
            float width = other.gameObject.renderer.bounds.size.x;


			if(EnvironmentManager.instance != null){
				EnvironmentManager.instance.obstacleList.Remove(other.gameObject);
				Destroy(other.gameObject);
				EnvironmentManager.instance.CreateObstacle();
			}
			CollisionHandle();
        }

		if (other.gameObject.tag == "CrossBeam")
		{
			float xDistance = Mathf.Abs(transform.position.x - other.transform.position.x);
			float width = other.gameObject.renderer.bounds.size.x;

			EnvironmentManager.instance.crossBeam.Remove(other.gameObject);
			Destroy(other.gameObject);
			EnvironmentManager.instance.CreateObstacle();
			CollisionHandle();
		}

    }
}
