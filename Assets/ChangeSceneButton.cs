using UnityEngine;
using System.Collections;

public class ChangeSceneButton : MonoBehaviour {

	public string level;

	void OnPress(bool isDown){
		if(!isDown){
			Application.LoadLevel(level);
		}
	}
}
