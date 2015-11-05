using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {
	//enter item number in the inspector
	public int itemNumber;
	
	//drag the AudioSource of whatever sound you want the pickup to make when picked up
	public AudioSource a;


	// Use this for initialization
	void Start () {
		a = GameObject.Find ("Pickup Weapon Sound").GetComponent<AudioSource> ();
		Destroy (gameObject, 4f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "PlayerBullet") {
			//check for what item this pickup is
			switch (itemNumber){
			//this is the health pickup
			case 1:
				col.gameObject.GetComponentInParent<HealthScript>().health += 10;
				break;
			//this is the rifle pickup. giving the player 50 shots for now but we can always change later
			case 2:
				col.gameObject.GetComponentInParent<Shoot>().ammo = 50;
				col.gameObject.GetComponentInParent<Shoot>().gunType = 1;
				col.gameObject.GetComponentInParent<Shoot>().ammoScale = 50;
				break;
			//this is the shot gun. around 5 bullets is pretty standard I think
			case 3:
				col.gameObject.GetComponentInParent<Shoot>().ammo = 5;
				col.gameObject.GetComponentInParent<Shoot>().gunType = 2;
				col.gameObject.GetComponentInParent<Shoot>().ammoScale = 5;
				break;
			default:
				break;
			}

			//play the sound for the pickup right before it is destroyed
			if (a!=null)
				a.Play ();
			Destroy (gameObject);
		}
	}
}
