using UnityEngine;
using System.Collections;

public class ShootAfterDelay : MonoBehaviour {
	
	public float delay = 1.0f;
	public GameObject e_Bullet;
	
	private GameObject player;
	
	private Animator animator;
	
	void Start () 
	{
		//player = GameObject.FindGameObjectWithTag("Player");
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
		Instantiate(e_Bullet, transform.position,Quaternion.LookRotation(Camera.main.transform.position - transform.position));
		
		//Play animation
		animator.SetBool ("Shoot", true);
		
		Invoke ("Shoot", delay);
	}
}
