using UnityEngine;
using System.Collections;

public class IncomingFire : MonoBehaviour 
{
	public float speed = 1.0f;
	public bool gibOnCollision = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += transform.forward * speed * Time.deltaTime;

	}

	void OnCollisionEnter()
	{
		if(gibOnCollision)
		{
			Destroy(gameObject);
		}
	}
}
