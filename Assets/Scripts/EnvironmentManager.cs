using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnvironmentManager : MonoBehaviour
{

    public GameObject player;

    public GameObject obstacle1;

    public List<GameObject> obstacleList = new List<GameObject>();
    public const int STARTCOUNT = 50;
    public const int OFFSET = 10;

    public List<GameObject> wallList = new List<GameObject>();
    public GameObject ground;
    public GameObject wall;


    public List<GameObject> groundList = new List<GameObject>();

    public int targetLane;
    public const float width = 1;
    public const float startLane = -12;

    public List<GameObject> rampList = new List<GameObject>();
    public GameObject ramp;

    public List<GameObject> crossBeam = new List<GameObject>();
    public GameObject beam;



    public static EnvironmentManager s_instance = null;
    public static EnvironmentManager instance
    {
        get
        {
            if (s_instance == null)
                Debug.LogError("uh.....oh shit don't exist!");
            return s_instance;
        }
    }

    // Use this for initialization
    void Start()
    {
        targetLane = 0;
        s_instance = this;
        for (int i = 10; i <= STARTCOUNT; i++)
        {
            float horX = Random.Range(-5, 6);
            horX = horX * 2;
            int scaleY = Random.Range(2, 13);
            obstacleList.Add((GameObject)Instantiate(obstacle1, new Vector3(horX, 1, i * 10), transform.rotation));
            obstacle1.transform.localScale = new Vector3(2, scaleY, 2);
        }
        for (int i = 0; i <= 6; i++)
        {
            groundList.Add((GameObject)Instantiate(ground, new Vector3(0, 0, i * ground.renderer.bounds.size.z), transform.rotation));

        }
        for (int i = 0; i <= 6; i++)
        {
            wallList.Add((GameObject)Instantiate(wall, new Vector3(-12f, 10, i * wall.renderer.bounds.size.z), wall.transform.rotation));
            wallList.Add((GameObject)Instantiate(wall, new Vector3(12f, 10, i * wall.renderer.bounds.size.z), wall.transform.rotation));
        }

        for (int i = 1; i <= 1000; i++)
        {
            float horX = Random.Range(-10, 10);
            rampList.Add((GameObject)Instantiate(ramp, new Vector3(horX, 0, i * 200), ramp.transform.rotation));
        }

        for (int i = 1; i <= 10; i++)
        {
            int side = Random.Range(0, 2);
            float Xpos = 0;
            if (side == 0)
            {
                Xpos = -12;
            }
            else 
            {
                Xpos = 12;
            }
            float horY = Random.Range(5, 10);
            crossBeam.Add((GameObject)Instantiate(beam, new Vector3(Xpos, horY, i * 50), beam.transform.rotation));
        }



    }

    // Update is called once per frame
    void Update()
    {
        //Obstacles
        for (int i = 0; i < obstacleList.Count; i++)
        {
            if (player.transform.position.z - OFFSET > obstacleList[i].transform.position.z)
            {
                Destroy(obstacleList[i]);
                obstacleList.Remove(obstacleList[i]);
                CreateObstacle();
                //obstacleList.Add ((GameObject)Instantiate(obstacle1, new Vector3(0, 0, player.transform.position.z + 100), transform.rotation)); 
            }
            else
            {
                break;
            }
        }

        for (int i = 0; i < crossBeam.Count; i++)
        {
            if (player.transform.position.z - OFFSET > crossBeam[i].transform.position.z)
            {
                Destroy(crossBeam[i]);
                crossBeam.Remove(crossBeam[i]);
                int side = Random.Range(0, 2);
                float Xpos = 0;
                if (side == 0)
                {
                    Xpos = -12;
                }
                else
                {
                    Xpos = 12;
                }
                float horY = Random.Range(5, 15);
                crossBeam.Add((GameObject)Instantiate(beam, new Vector3(Xpos, horY, player.transform.position.z + 500), beam.transform.rotation));
                //obstacleList.Add ((GameObject)Instantiate(obstacle1, new Vector3(0, 0, player.transform.position.z + 100), transform.rotation)); 
            }
            else
            {
                break;
            }
        }

        /*for (int i = 0; i < rampList.Count; i++)
        {
            if (player.transform.position.z - OFFSET > rampList[i].transform.position.z)
            {
                float horX = Random.Range(-10, 10);
                Destroy(rampList[i]);
                rampList.Remove(rampList[i]);
                rampList.Add((GameObject)Instantiate(ramp, new Vector3(horX, 0, player.transform.position.z + 100), ramp.transform.rotation));
                i--;
            }
            else
            {
                break;
            }
        }*/

        //Ground
        for (int i = 0; i < groundList.Count; i++)
        {
            if (player.transform.position.z - OFFSET > groundList[i].transform.position.z + groundList[i].renderer.bounds.size.z / 2)
            {
                groundList.Add((GameObject)Instantiate(ground, new Vector3(0, 0, groundList[groundList.Count - 1].renderer.bounds.size.z + groundList[groundList.Count - 1].transform.position.z), transform.rotation));

                Destroy(groundList[i]);
                groundList.Remove(groundList[i]);
            }
            else
            {
                break;
            }
        }

        //Walls yo
        for (int i = 0; i < wallList.Count; i++)
        {
            if (player.transform.position.z - OFFSET > wallList[i].transform.position.z + wallList[i].renderer.bounds.size.z / 2)
            {
                wallList.Add((GameObject)Instantiate(wall, new Vector3(-12f, 10, wallList[wallList.Count - 1].renderer.bounds.size.z + wallList[wallList.Count - 1].transform.position.z), wall.transform.rotation));
                wallList.Add((GameObject)Instantiate(wall, new Vector3(12f, 10, wallList[wallList.Count - 2].renderer.bounds.size.z + wallList[wallList.Count - 2].transform.position.z), wall.transform.rotation));
                Destroy(wallList[i]);
                wallList.Remove(wallList[i]);
            }
            else
            {
                break;
            }
        }

    }

    public void CreateObstacle()
    {
        float horX = Random.Range(-5, 6);
        horX = horX * 2;
        float scaleY = Random.Range(2, 10);
        obstacleList.Add((GameObject)Instantiate(obstacle1, new Vector3(horX, 1, player.transform.position.z + 400), transform.rotation));
        obstacle1.transform.localScale = new Vector3(2, scaleY, 2);
    }
}
