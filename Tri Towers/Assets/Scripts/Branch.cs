using UnityEngine;
using System.Collections;

public class Branch : MonoBehaviour {
	public GameObject OtherRoute;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){
		OtherRoute.SetActive (false);
		Destroy (gameObject);
	}
}
