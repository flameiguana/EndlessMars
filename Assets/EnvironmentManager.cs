using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnvironmentManager : MonoBehaviour {

	public GameObject player;

	public GameObject obstacle1;

	public List<GameObject> obstacleList = new List<GameObject>();
	public const int STARTCOUNT = 10;
	public const int OFFSET = 5;

	public GameObject ground;

	public List<GameObject> groundList = new List<GameObject> ();


	// Use this for initialization
	void Start () 
	{
		for (int i = 1; i <= STARTCOUNT; i++) 
		{
			float horX = Random.Range (-10, 10);
			obstacleList.Add((GameObject)Instantiate(obstacle1, new Vector3(horX, 0, i * 10), transform.rotation));
		}
		for (int i = 0; i <= 2; i++) 
		{
			groundList.Add ((GameObject)Instantiate(ground, new Vector3(0, 0, i * ground.renderer.bounds.size.z), transform.rotation));
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

		for(int i = 0 ; i < obstacleList.Count; i++)
		{
			if(player.transform.position.z - OFFSET > obstacleList[i].transform.position.z)
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
		for(int i = 0 ; i < groundList.Count; i++)
		{
			if(player.transform.position.z - OFFSET > groundList[i].transform.position.z + groundList[i].renderer.bounds.size.z/2)
			{
				groundList.Add ((GameObject)Instantiate(ground, new Vector3(0, 0, groundList[groundList.Count-1].renderer.bounds.size.z + groundList[groundList.Count-1].transform.position.z), transform.rotation)); 
			
				Destroy(groundList[i]);
				groundList.Remove(groundList[i]);
			}
			else
			{
				break;
			}
		}

	}

	void CreateObstacle()
	{
		float horX = Random.Range (-10, 10);
		obstacleList.Add ((GameObject)Instantiate(obstacle1, new Vector3(horX, 0, player.transform.position.z + 100), transform.rotation)); 
	}
}
