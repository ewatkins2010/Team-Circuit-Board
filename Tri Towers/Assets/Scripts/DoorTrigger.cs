using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public Animator Door;
	void Start(){
		Door.enabled = false;
	}
	void OnTriggerEnter(Collider Other)
	{
		if(Other.gameObject.tag == "Player")
		{
			Door.enabled = true;
		}
	}
}
