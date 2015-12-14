using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {
	public bool isBullet;
	public GameObject particle;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){
		if (isBullet)
			Instantiate (particle, transform.position, transform.rotation);
	}

	void OnCollisionEnter(Collision col){
		if (isBullet) {
			Instantiate (particle, transform.position, transform.rotation);
		}
		if (col.gameObject.tag == "EnemyBullet") {
			GetComponentInParent<HealthScript>().score += 50;
			if (GetComponentInParent<Shoot>().gunType != 2)
				Destroy (gameObject);
		}
		Destroy (gameObject);
	}
}
