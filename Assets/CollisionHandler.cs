using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{

    public GameObject player;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

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
            Destroy(gameObject);

            //}

            EnvironmentManager.instance.obstacleList.Remove(other.gameObject);
            Destroy(other.gameObject);
            EnvironmentManager.instance.CreateObstacle();

            //yield WaitForSeconds(5.0);
            Application.LoadLevel(Application.loadedLevel);

        }

    }
}
