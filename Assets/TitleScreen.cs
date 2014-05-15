﻿using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	public GameObject PlayButton;
	public GameObject CreditsButton;
	public GameObject InfoButton;


	// Use this for initialization
	void Start () {
		UIEventListener.Get(PlayButton).onPress += PlayButtonPress;
	}

	void PlayButtonPress(GameObject button, bool isDown){
		if(isDown)
			return;
		Application.LoadLevel(1);
	}

}
