﻿using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		Destroy (gameObject);
	}
}
