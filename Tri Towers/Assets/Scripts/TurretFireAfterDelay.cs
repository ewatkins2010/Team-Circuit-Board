using UnityEngine;
using System.Collections;

public class TurretFireAfterDelay : MonoBehaviour {

	public float delay = 1.0f;
	public GameObject e_Bullet;

	private Animator animator;

	void Start () 
	{
		animator = GetComponentInChildren<Animator>();
		Invoke ("Shoot", delay);
	}

	void LateUpdate()
	{
		animator.SetBool ("Shoot", false);
	}

	void Shoot () 
	{
		//Deal damage to player (TBA)

		//Play animation
		animator.SetBool ("Shoot", true);

		Invoke ("Shoot", delay);
	}
}
