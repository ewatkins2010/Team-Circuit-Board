using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

	public float rotationSpeed = 90;

	private Transform playerCamera;

	// Use this for initialization
	void Start () 
	{
		playerCamera = Camera.main.transform;
		StartCoroutine (LookNow ());
	}

	IEnumerator LookNow()
	{
		Quaternion goalRotation;

		goalRotation = Quaternion.LookRotation (transform.position - playerCamera.position);

		while(true)
		{
			playerCamera.rotation = Quaternion.RotateTowards(playerCamera.rotation,goalRotation, rotationSpeed*Time.deltaTime);

			if(playerCamera.rotation != goalRotation)
			{
				yield return null;
			}
			else
			{
				break;
			}
		}
	}
}
