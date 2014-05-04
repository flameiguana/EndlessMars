using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    private int distanceTraveled;
    private int score;
    public GameObject player;
    public GUIText playerScore;
    private float currentDistance;
    public int health;

	// Use this for initialization
	void Start () 
    {
        score = 0;
        distanceTraveled = 0;
        health = 10;
	}
	
	// Update is called once per frame
	void Update () 
    {
        currentDistance = (int)player.transform.position.z;
        playerScore.text = "Metres: " + currentDistance.ToString();
	}
}
