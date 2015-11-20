using UnityEngine;
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
		if (col.gameObject.tag == "EnemyBullet") {
			GetComponentInParent<HealthScript>().score += 50;
			if (GetComponentInParent<Shoot>().gunType != 2)
				Destroy (gameObject);
		}
		Destroy (gameObject);
	}
}
