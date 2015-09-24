using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {
	public int itemNumber;
	public HealthScript h;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "PlayerBullet") {
			switch (itemNumber){
			case 1:
				h.health += 10;
				break;
			case 2:
				break;
			default:
				break;
			}
		}
		Destroy (gameObject);
	}
}
