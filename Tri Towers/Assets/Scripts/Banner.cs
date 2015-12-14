using UnityEngine;
using System.Collections;

public class Banner : MonoBehaviour {
	public bool turnBlue, turnGreen;
	public Texture[] colors;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Reset(){
		GetComponent<MeshRenderer>().material.mainTexture = colors[2];
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "PlayerBullet") {
			if (turnBlue)
				GetComponent<MeshRenderer>().material.mainTexture = colors[0];
			if (turnGreen)
				GetComponent<MeshRenderer>().material.mainTexture = colors[1];
			col.gameObject.GetComponentInParent<HealthScript>().score += 500;
			GetComponent<Animator>().SetTrigger("Off");
		}
	}
}
