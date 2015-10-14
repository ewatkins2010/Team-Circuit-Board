using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {
	//drag in the bullet and BigBullet prefabs into these slots
	public Rigidbody bullet;
	public Rigidbody bigBullet;
	
	//defalut force of the gun
	public float force = 10.0f;
	public ForceMode forceMode;
	
	//ammo will eventually increase when you shoot an ammo pickup. 
	public int ammo, gunType;
	public Text ammoDisplay;
	public Image reticle;
	
	//drag in all of the reticles into this array. they should be set as cursors and not textures or sprites
	//hotspot is the center of the reticle
	public Sprite[] sprites;
	
	//tells the gun if it can fire or not;
	public bool canFire;
	
	// Use this for initialization
	void Start ()
	{
		canFire = true;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void CheckGun(string button){
		ammoDisplay.text = ammo + "";
		//if the gun can fire, then shoot
		if (canFire){
			switch (gunType){
				//this is the pistol
			case 0:
				reticle.sprite = sprites[0];
				if (Input.GetButtonDown (button))
					StartCoroutine (fire (.3f, bullet, 1f));
				break;
				//this is the rifle, it has a faster rate of fire
			case 1:
				reticle.sprite = sprites[1];
				if (Input.GetButton (button))
					StartCoroutine (fire (.1f, bullet, 1f));
				break;
				//this is the shot gun. it uses the BigBullet and has a slower rate of fire
			case 2:
				reticle.sprite = sprites[2];
				if (Input.GetButtonDown (button))
					StartCoroutine (fire (1f, bigBullet, 1.3f));
				break;
			default:
				break;
			}
		}
	}

	public void Reset(){
		ammo = 0;
		gunType = 0;
	}

	IEnumerator fire(float rate, Rigidbody b, float boost){
		//getting mouse position with raycasting
		Ray ray = Camera.main.ScreenPointToRay(reticle.transform.position);
		Quaternion rotation = Quaternion.LookRotation(ray.direction);
		
		//Instantiating the bullet and giving it force to move
		Rigidbody instance = Instantiate(b,Camera.main.transform.position,rotation) as Rigidbody;
		instance.AddForce(ray.direction*force*boost, forceMode);
		instance.transform.SetParent (transform);
		
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
