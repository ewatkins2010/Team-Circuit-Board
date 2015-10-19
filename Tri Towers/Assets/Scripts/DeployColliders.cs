using UnityEngine;
using System.Collections;

public class DeployColliders : MonoBehaviour {
	GameObject box1,box2;
	CursorMove c;
	// Use this for initialization
	void Start () {
		c = GameObject.Find ("P1").GetComponent<CursorMove> ();
		box1 = GameObject.Find ("P1 Collider");
		box2 = GameObject.Find ("P2 Collider");

		if (c.solo) {
			box1.SetActive (false);
			box2.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
