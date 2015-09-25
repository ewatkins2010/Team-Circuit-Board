using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
	public Rigidbody bullet;
	public float force = 10.0f;
	public ForceMode forceMode;
	public int ammo, gunType;
	public Texture2D reticle;
	public bool canFire;
	Vector2 hotspot;
	//public CursorMode reticle;
	
	// Use this for initialization
	void Start ()
	{
		canFire = true;
		hotspot = new Vector2 (reticle.width / 2, reticle.height / 2);
		Cursor.SetCursor (reticle, hotspot, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, GetComponent<Camera>().nearClipPlane));
		if (canFire){
		switch (gunType){
			case 0:
				if(Input.GetMouseButtonDown(0))
					StartCoroutine (fire (.3f));
				break;
			case 1:
				if(Input.GetMouseButton(0))
					StartCoroutine (fire (.1f));
				break;
			default:
				break;
			}
		}
	}
	IEnumerator fire(float rate){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Quaternion rotation = Quaternion.LookRotation(ray.direction);
		Rigidbody instance = Instantiate(bullet,transform.position,rotation) as Rigidbody;
		instance.AddForce(ray.direction*force, forceMode);
		canFire = false;
		yield return new WaitForSeconds (rate);
		canFire = true;
	}
}

