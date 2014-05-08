using UnityEngine;
using System.Collections;

public class InGameUI : MonoBehaviour {
	
	public UIPanel PausePanel;

	bool paused = false;
	void Awake(){
		PausePanel.gameObject.SetActive(false);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			PauseToggle();
		}
	}

	void PauseToggle(){
		paused = !paused;
		SetPauseState(paused);
		PausePanel.gameObject.SetActive(paused);
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
}
