﻿using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {
	public bool alone;
	public GameObject player2;

	public int score1, score2, nextLevel;
	public string died;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnLevelWasLoaded(int level){
	}

	public void IsAlone(bool choice){
		alone = choice;
	}

	public void CheckPlayers(){
		player2 = GameObject.Find ("P2");
		if (alone) {
			player2.SetActive (false);
		}
	}

	public void DropIn(){
		player2.SetActive (true);
	}

	public void DropOut(){
		player2.SetActive (false);
	}
}
