using UnityEngine;
using System.Collections;

public class Message : MonoBehaviour {
	public GameObject m;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(){
		Instantiate (m, transform.position, Quaternion.identity);
	}
}
