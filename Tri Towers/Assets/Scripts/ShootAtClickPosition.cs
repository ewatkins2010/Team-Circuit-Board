using UnityEngine;
using System.Collections;

public class ShootAtClickPosition : MonoBehaviour
{
	public Rigidbody bullet;
	public float force = 10.0f;
	public ForceMode forceMode;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Quaternion rotation = Quaternion.LookRotation(ray.direction);

//			Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, GetComponent<Camera>().nearClipPlane));

			Rigidbody instance = Instantiate(bullet,transform.position,rotation) as Rigidbody;
			instance.AddForce(ray.direction*force, forceMode);
		}
	}
}
