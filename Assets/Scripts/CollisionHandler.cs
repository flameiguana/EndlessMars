using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
	public bool shielded;
	Shield currentShield;
    public GameObject explosion;
    public AudioSource shieldPowerDown;


	public void GiveShield(Shield shield){
        if (!shielded)
        {
            shield.transform.parent = transform;
            shield.transform.localPosition = Vector3.zero;
            currentShield = shield;
            shielded = true;
        }
        else
        {
            Destroy(shield);
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
		


			if(!shielded){
				if(onDeath != null){
                    GameObject currentExplosion = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
					onDeath(gameObject);
				}
			}
			else {
				Destroy (currentShield.gameObject);
                shieldPowerDown.Play();
				shielded = false;
				currentShield = null;
			}
        }

		if (other.gameObject.tag == "CrossBeam")
		{
			float xDistance = Mathf.Abs(transform.position.x - other.transform.position.x);
			float width = other.gameObject.renderer.bounds.size.x;

			EnvironmentManager.instance.crossBeam.Remove(other.gameObject);
			Destroy(other.gameObject);
			EnvironmentManager.instance.CreateObstacle();
			
			if(!shielded){
				if(onDeath != null){
					onDeath(gameObject);
				}
			}
			else {
                shieldPowerDown.Play();
				Destroy (currentShield.gameObject);
				shielded = false;
				currentShield = null;
			}
		}

    }
}
