using UnityEngine;
using System.Collections;

public class GibOnCollide : MonoBehaviour
{
	public GameObject gib;
	public float delay;
	public bool isHostage;
	public bool gibOnCollision = true;
	public bool gibOnTrigger = true;
	public GameObject[] pickUps;
	public Transform itemSpawn;
	AudioSource a;
	Animator anim;
	bool isAlive;

	// Use this for initialization
	void Start () {
		a = GameObject.Find ("Explosion").GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		isAlive = true;
	}

	void OnTriggerEnter(Collider col)
	{
		if(gibOnTrigger && isAlive)
		{
			if (col.gameObject.tag == "PlayerBullet") {
				if (col.GetComponentInParent<Shoot>().gunType != 2)
					Destroy (col.gameObject);
				if (tag == "Enemy"){
					col.GetComponentInParent<HealthScript>().score += 100;
					StartCoroutine("GibNow");
				}
				else if (tag == "Hostage"){
					col.GetComponentInParent<HealthScript>().score -= 100;
					col.GetComponentInParent<HealthScript>().health -= 50f;
					StartCoroutine("GibNow");
				}
				else
					JustDie ();
			}
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
		GetComponent<BoxCollider> ().enabled = false;
		yield return new WaitForSeconds (delay);
		a.Play ();
		Instantiate (gib, transform.position, gib.transform.rotation);

		if (!isHostage) {
			DropItem ();
		}

		Destroy (gameObject);
	}

	void DropItem(){
		int random = Random.Range(0,10);
		if (random >= 0 && random <= 1) {
			GameObject instance = Instantiate (pickUps [0], itemSpawn.position, transform.rotation) as GameObject;
			instance.transform.SetParent (transform.parent);
		} 
		if (random == 2 || random == 3) {
			GameObject instance = Instantiate (pickUps [1], itemSpawn.position, transform.rotation) as GameObject;
			instance.transform.SetParent (transform.parent);
		} 
		if (random == 4 || random == 5) {
			GameObject instance = Instantiate (pickUps [2], itemSpawn.position, transform.rotation) as GameObject;
			instance.transform.SetParent (transform.parent);
		}
	}

	void JustDie(){
		GetComponent<EnemiesShootAfterDelay> ().canShoot = false;
		Destroy (gameObject);
	}
}
