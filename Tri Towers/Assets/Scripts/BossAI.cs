using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {
	public Transform[] Waypoints1, Waypoints2, guns;
	public GameObject bullet;
	public float speed;
	public bool doPatrol, rageMode;

	int curWaypoint, phase;
	Vector3 Target, MoveDirection, Velocity;
	bool canFire;
	Animator anim;
	GameObject player, box1, box2, p1;
	
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
		box1 = GameObject.FindGameObjectWithTag ("P1");
		box2 = GameObject.FindGameObjectWithTag ("P2");
		p1 = GameObject.Find("P1");
		phase = 1;
		canFire = true;
	}
	
	void Update () {
		switch (phase) {
		case 1:
			Move (Waypoints1);
			break;
		case 2:
			if (canFire){
				if (rageMode){
					StartCoroutine("DoubleShoot");
				}
				else {
					StartCoroutine ("Shoot");
				}
			}
			break;
		case 3:
			Move (Waypoints2);
			break;
		default:
			break;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "PlayerBullet") {
			StartCoroutine ("Hit");
		}
	}

	IEnumerator Hit(){
		canFire = false;
		GetComponent<BoxCollider> ().enabled = true;
		//anim.SetTrigger ("Hit");
		yield return new WaitForSeconds (1f);
		phase = 3;
		doPatrol = true;
	}

	IEnumerator DoubleShoot(){
		canFire = false;
		Transform target1, target2;
		if (p1.GetComponent<CursorMove> ().solo) {
			target1 = player.transform;
			Instantiate (bullet, guns[0].position, Quaternion.LookRotation (target1.position - guns[0].position));
		    Instantiate (bullet, guns[1].position, Quaternion.LookRotation (target1.position - guns[1].position));
		}
		else {
			target1 = box1.transform;
			target2 = box2.transform;
			Instantiate (bullet, transform.position, Quaternion.LookRotation (target1.position - guns[0].position));
			Instantiate (bullet, transform.position, Quaternion.LookRotation (target2.position - guns[1].position));
		}
		yield return new WaitForSeconds (1);
		canFire = true;
	}

	IEnumerator Shoot(){
		canFire = false;
		Transform target;
		if (p1.GetComponent<CursorMove> ().solo)
			target = player.transform;
		else {
			int random = Random.Range (1,10);
			if (random <= 5)
				target = box1.transform;
			else
				target = box2.transform;
		}
		anim.SetTrigger ("1Shot");
		yield return new WaitForSeconds (2f);
		Instantiate (bullet, guns[0].position, Quaternion.LookRotation (target.position - guns[0].position));
		canFire = true;
	}

	void Move(Transform[] w){
		if(curWaypoint < w.Length & doPatrol)
		{
			Target = w[curWaypoint].position;
			MoveDirection = Target - transform.position;
			Velocity = GetComponent<Rigidbody>().velocity;
			
			if(MoveDirection.magnitude < 1)
				curWaypoint++;
			else{
				Velocity = MoveDirection.normalized * speed;
				anim.SetBool ("Run", true);
			}
		}
		else
		{
			if(doPatrol)
				doPatrol = false;
			else {
				Velocity = Vector3.zero;
				Target = player.transform.position;
				anim.SetBool ("Run", false);
				if (phase == 1) {
					phase = 2;
					curWaypoint = 0;
				}
				if (phase == 3)
					Destroy (gameObject);
			}
		}
		
		GetComponent<Rigidbody>().velocity = Velocity;
		transform.LookAt (Target);
	}
}
