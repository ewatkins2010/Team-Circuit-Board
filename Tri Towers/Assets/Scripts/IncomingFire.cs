using UnityEngine;
using System.Collections;

public class IncomingFire : MonoBehaviour 
{
	public float speed = 1.0f;
	public bool gibOnCollision = true;
	public GameObject p1, p2;
	public AudioSource a, b;

	// Use this for initialization
	void Start () {
		a = GameObject.Find ("Hit").GetComponent<AudioSource> ();
		b = GameObject.Find ("Barrier Hit").GetComponent<AudioSource> ();
		Destroy (gameObject, 3f);
		p1 = GameObject.Find ("P1");
		p2 = GameObject.Find ("P2");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log (col.gameObject.name);

		if (col.gameObject.tag == "P1" || col.gameObject.tag == "Player") {
			a.Play ();
			p1.GetComponentInChildren<HealthScript>().health-=10f;
		}
		if (col.gameObject.tag == "P2") {
			a.Play ();
			p2.GetComponentInChildren<HealthScript>().health-=10f;
		}
		if (col.gameObject.tag == "BarrierP1") {
			b.Play ();
			p1.GetComponentInChildren<Shoot>().shieldHit += 1;
		}
		if (col.gameObject.tag == "BarrierP2") {
			b.Play ();
			p2.GetComponentInChildren<Shoot>().shieldHit += 1;
		}
		Destroy (gameObject);
	}
}
