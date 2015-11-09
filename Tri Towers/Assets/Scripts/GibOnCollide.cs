using UnityEngine;
using System.Collections;

public class GibOnCollide : MonoBehaviour
{
	public GameObject gib;
	public float delay;
	public bool gibOnCollision = true;
	public bool gibOnTrigger = true;
	public GameObject[] pickUps;
	public Transform itemSpawn;
	public AudioSource a;
	Animator anim;
	bool isAlive;

	// Use this for initialization
	void Start () {
		a = GameObject.Find ("Explosion").GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		isAlive = true;
	}

	void OnTriggerEnter()
	{
		if(gibOnTrigger && isAlive)
		{
			if (tag == "Enemy")
				StartCoroutine("GibNow");
			else
				JustDie ();
		}
	}

	// Update is called once per frame
	void OnCollisionEnter()
	{
		if(gibOnCollision && isAlive)
		{
			if (tag == "Enemy")
				StartCoroutine("GibNow");
			else
				JustDie ();
		}
	}

	IEnumerator GibNow()
	{	
		isAlive = false;
		GetComponentInChildren<EnemiesShootAfterDelay> ().canShoot = false;
		anim.SetTrigger ("Death");
		yield return new WaitForSeconds (delay);
		a.Play ();
		Instantiate (gib, transform.position, gib.transform.rotation);
		int random = Random.Range(1,10);
		Debug.Log (random);
		if (random >= 1 && random <= 3) {
			GameObject instance = Instantiate (pickUps [0], itemSpawn.position, transform.rotation) as GameObject;
			instance.transform.SetParent (transform.parent);
		} 
		if (random == 4 || random == 5) {
			GameObject instance = Instantiate (pickUps [1], itemSpawn.position, transform.rotation) as GameObject;
			instance.transform.SetParent (transform.parent);
		} 
		if (random == 6 || random == 7) {
			GameObject instance = Instantiate (pickUps [2], itemSpawn.position, transform.rotation) as GameObject;
		}
		Destroy (gameObject);
	}
	void JustDie(){
		GetComponent<EnemiesShootAfterDelay> ().canShoot = false;
		Destroy (gameObject);
	}
}
