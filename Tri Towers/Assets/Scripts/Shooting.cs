using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
	//drag in the bullet and BigBullet prefabs into these slots
	public Rigidbody bullet;
	public Rigidbody bigBullet;

	//defalut force of the gun
	public float force = 10.0f;
	public ForceMode forceMode;

	//ammo will eventually increase when you shoot an ammo pickup. 
	public int ammo, gunType;

	//drag in all of the reticles into this array. they should be set as cursors and not textures or sprites
	//hotspot is the center of the reticle
	public Texture2D[] reticles;
	Vector2 hotspot;

	//tells the gun if it can fire or not;
	public bool canFire;
	
	// Use this for initialization
	void Start ()
	{
		canFire = true;
		hotspot = new Vector2 (reticles[0].width / 2, reticles[0].height / 2);
		Cursor.SetCursor (reticles[0], hotspot, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, GetComponent<Camera>().nearClipPlane));

		//if the gun can fire, then shoot
		if (canFire){
		switch (gunType){
			//this is the pistol
			case 0:
				Cursor.SetCursor (reticles[0], hotspot, CursorMode.Auto);
				if(Input.GetMouseButtonDown(0))
					StartCoroutine (fire (.3f, bullet, 1f));
				break;
			//this is the rifle, it has a faster rate of fire
			case 1:
				Cursor.SetCursor (reticles[1], hotspot, CursorMode.Auto);
				if(Input.GetMouseButton(0))
					StartCoroutine (fire (.1f, bullet, 1f));
				break;
			//this is the shot gun. it uses the BigBullet and has a slower rate of fire
			case 2:
				Cursor.SetCursor (reticles[2], hotspot, CursorMode.Auto);
				if(Input.GetMouseButton(0))
					StartCoroutine (fire (1f, bigBullet, 2f));
				break;
			default:
				break;
			}
		}
	}
	IEnumerator fire(float rate, Rigidbody b, float boost){
		//getting mouse position with raycasting
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Quaternion rotation = Quaternion.LookRotation(ray.direction);

		//Instantiating the bullet and giving it force to move
		Rigidbody instance = Instantiate(b,transform.position,rotation) as Rigidbody;
		instance.AddForce(ray.direction*force*boost, forceMode);

		//telling the gun not to fire after initial shot
		canFire = false;

		//if the gun has ammo, subtract ammo from the total
		if (ammo > 0)
			ammo--;

		//wait for however long the rate of fire is in seconds
		yield return new WaitForSeconds (rate);

		//allow the gun to fire again
		canFire = true;

		//if there is no more ammo, switch back to the pistol
		if (ammo == 0)
			gunType = 0;
	}
}

