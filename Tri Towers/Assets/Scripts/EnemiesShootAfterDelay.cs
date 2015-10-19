using UnityEngine;
using System.Collections;

public class EnemiesShootAfterDelay : MonoBehaviour {
	
	public float delay = 1.0f;
	public GameObject e_Bullet;
	public Transform shootPoint;
	public bool canShoot;
	
	private GameObject p1;
	private Animator animator;
	private GameObject box1, box2, cam;
	
	void Start () 
	{
		box1 = GameObject.FindGameObjectWithTag ("P1");
		box2 = GameObject.FindGameObjectWithTag ("P2");
		cam = GameObject.Find ("Main Camera");
		canShoot = true;
		p1 = GameObject.Find("P1");
		animator = GetComponentInParent<Animator>();
		Invoke ("Shoot", delay);
	}
	
	void LateUpdate()
	{
		//animator.SetBool ("Shoot", false);
	}
	
	void Shoot () 
	{
		Transform target;
		if (p1.GetComponent<CursorMove> ().solo)
			target = cam.transform;
		else {
			int random = Random.Range (1,10);
			if (random <= 5)
				target = box1.transform;
			else
				target = box2.transform;
			Debug.Log (random);
		}
		if (canShoot) {
			GameObject instance;
			instance = Instantiate (e_Bullet, transform.position, Quaternion.LookRotation (target.position - shootPoint.position)) as GameObject;
			instance.transform.SetParent (transform.root);
			//Play animation
			animator.SetTrigger ("Fire");
			Invoke ("Shoot", delay);
		}
	}
}
