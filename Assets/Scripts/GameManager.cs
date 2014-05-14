using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public UIPanel gameOverPanel;
	public UIPanel PausePanel;

	bool gameOver = false;
	bool paused = false;

	void Start(){
		PausePanel.gameObject.SetActive(false);
	}

	void OnEnable(){
		CollisionHandler.onDeath += HandleDeath;
	}

	void OnDisable(){
		CollisionHandler.onDeath -= HandleDeath;
	}

	void HandleDeath(GameObject gameObject){
		Destroy(gameObject);
		gameOver = true;
		gameOverPanel.gameObject.SetActive(true);
	}

	void Restart(){
		Application.LoadLevel(Application.loadedLevel);
	}
	
	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			PauseToggle();
		}
	}

	//keep this here until we get a gamestate manager
	void SetPauseState(bool pause){
		if(pause){
			Time.timeScale = 0f;
		}
		else {
			Time.timeScale = 1f;
		}
	}
	
	void PauseToggle(){
		if(gameOver)
			return;
		paused = !paused;
		SetPauseState(paused);
		PausePanel.gameObject.SetActive(paused);
	}

}
