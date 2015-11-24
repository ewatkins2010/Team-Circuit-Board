using UnityEngine;
using System.Collections;

public class TurretPatrol : MonoBehaviour {
	public Transform[] Waypoints;
	public float Speed;
	public int curWayPoint;
	public bool doPatrol;
	public Vector3 Target;
	public Vector3 MoveDirection;
	public Vector3 Velocity;
	public bool initialRotation;
	public Animator anim;
	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
	}

	void Update () {

		if(curWayPoint < Waypoints.Length & doPatrol)
		{
			Target = Waypoints[curWayPoint].position;
			MoveDirection = Target - transform.position;
			Velocity = GetComponent<Rigidbody>().velocity;

			if(MoveDirection.magnitude < 1)
				curWayPoint++;
			else{
				Velocity = MoveDirection.normalized * Speed;
				anim.SetBool ("Fire", true);
			}

		}
		else
		{
			if(doPatrol)
				doPatrol = false;
			else {
				Velocity = Vector3.zero;
				Target = player.transform.position;
				anim.SetBool ("Fire", false);
			}
		}

		GetComponent<Rigidbody>().velocity = Velocity;
		transform.LookAt (Target);
	}
}
