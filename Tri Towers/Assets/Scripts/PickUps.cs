using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {
	//enter item number in the inspector
	public int itemNumber;

	//drag whatever has the shooting script and the health script into these fields in the inspector
	//drag the AudioSource of whatever sound you want the pickup to make when picked up
	public HealthScript h;
	public Shooting s;
	public AudioSource a;


	// Use this for initialization
	void Start () {

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
				h.health += 10;
				break;
			//this is the rifle pickup. giving the player 50 shots for now but we can always change later
			case 2:
				s.ammo = 50;
				s.gunType = 1;
				break;
			//this is the shot gun. around 5 bullets is pretty standard I think
			case 3:
				s.ammo = 5;
				s.gunType = 2;
				break;
			default:
				break;
			}
		}
		//play the sound for the pickup right before it is destroyed
		a.Play ();
		Destroy (gameObject);
	}
}
