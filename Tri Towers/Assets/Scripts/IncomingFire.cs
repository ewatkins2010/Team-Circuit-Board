using UnityEngine;
using System.Collections;

public class IncomingFire : MonoBehaviour 
{
	public float speed = 1.0f;
	public bool gibOnCollision = true;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += transform.forward * speed * Time.deltaTime;

	}

	void OnCollisionEnter(Collision col)
	{
		/*if(gibOnCollision)
		{
			Destroy(gameObject);
		}*/
		Debug.Log ("hit something");
		Debug.Log (col.gameObject.name);
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponentInChildren<HealthScript>().health-=10f;
		}
		Destroy (gameObject);
	}
}
