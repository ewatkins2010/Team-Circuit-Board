using UnityEngine;
using System.Collections;

public class GibOnCollide : MonoBehaviour
{
	public GameObject gib;
	public bool gibOnCollision = true;
	public bool gibOnTrigger = true;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter()
	{
		if(gibOnTrigger)
		{
			GibNow ();
		}
	}

	// Update is called once per frame
	void OnCollisionEnter()
	{
		if(gibOnCollision)
		{
			GibNow();
		}
	}

	void GibNow()
	{
		Instantiate (gib, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
