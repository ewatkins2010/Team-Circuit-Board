using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Edward Watkins
//Shooting script for Tri Towers

public class Shoot : MonoBehaviour {
	//drag in the bullet and BigBullet prefabs into these slots
	public Rigidbody[] bullets;

	//defalut force of the gun
	public float force = 10.0f;
	public ForceMode forceMode;
	
	//ammo will eventually increase when you shoot an ammo pickup. 
	public int ammo, gunType; 
	public Image reticle, ammoBar;
	public GameObject shieldIcon, reloadText;
	
	//drag in all of the reticles into this array. they should be set as cursors and not textures or sprites
	public Sprite[] sprites;
	//array for the shield game objects in the scene
	public GameObject[] shields;
	//array for the gun images on the HUD
	public Image[] gunIcons;

	//the number of hits the shield has taken
	[HideInInspector]public int shieldHit;
	//booleans to check if the player can shield and if the player can shoot
	[HideInInspector]public bool canShield, canFire;

	//scale to manage the ammo bar
	public float ammoScale;

	//gets the player number from the CursorMove Component
	CursorMove playerNumber;
	//AudioSources for firing and reloading
	AudioSource a, r;
	//player 1 needs to know whether to use the solo shield or the co-op shield
	//max hit is the max amount of hits the shield can take
	int shieldIndex, shieldMaxHit;
	
	// Use this for initialization
	void Start ()
	{
		//initializing needed variables
		playerNumber = GetComponent<CursorMove> ();
		a = GameObject.Find ("Player Fire").GetComponent<AudioSource> ();
		r = GameObject.Find ("Reload").GetComponent<AudioSource> ();
		canFire = true;
		canShield = true;
		ammo = 5;
		ammoScale = 5;
		shieldHit = 0;

		//if playing solo, use the bigger and stronger shield
		//else use the smaller and weaker shield
		if (playerNumber.solo) {
			shieldIndex = 1;
			shieldMaxHit = 6;
		}
		else {
			shieldIndex = 0;
			shieldMaxHit = 3;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		//ammo bar gets smaller as the player runs out of ammo from firing the gun
		if (ammoBar != null)
			ammoBar.GetComponent<RectTransform> ().localScale = new Vector3 (1, ammo / ammoScale, 1);

	}

	public void Shield(string button){
		//if the shield has taken too many hits, run the cool down
		if (shieldHit >= shieldMaxHit) {
			canShield = false;
			StartCoroutine ("Recharge");
		}
		//if there are shields and you're able to use them, the use the shield if te button is held
		if (shields [shieldIndex] != null) {
			if (canShield && Input.GetButton (button)) {
				shields [shieldIndex].SetActive (true);
			} else {
				shields [shieldIndex].SetActive (false);
			}
		}
	}

	//runs a 10 second delay before the shield is reusable
	public IEnumerator Recharge(){
		shieldIcon.GetComponent<Animator> ().SetBool ("Fade", true);
		yield return new WaitForSeconds (10f);
		shieldIcon.GetComponent<Animator> ().SetBool ("Fade", false);
		canShield = true;
		shieldHit = 0;
	}

	//if using the standard gun, you're able to reload with the reload button
	public void Reload(string button){
		if (gunType == 0) {
			if (Input.GetButtonDown (button)){
				reloadText.SetActive (false);
				r.Play ();
				ammo = 5;
				canFire = true;
			}
		}
	}

	public void CheckGun(string button){
		//if the gun can fire, then shoot
		if (canFire && !shields[shieldIndex].activeInHierarchy){
			switch (gunType){
				//this is the pistol
			case 0:
				reticle.sprite = sprites[0];
				if (Input.GetButtonDown (button))
					StartCoroutine (fire (.2f, bullets[0]));
				break;
				//this is the rifle, it has a faster rate of fire
			case 1:
				reticle.sprite = sprites[1];
				if (Input.GetButton (button))
					StartCoroutine (fire (.1f, bullets[1]));
				break;
				//this is the shot gun. it uses the BigBullet and has a slower rate of fire
			case 2:
				reticle.sprite = sprites[2];
				if (Input.GetButtonDown (button))
					StartCoroutine (fire (.5f, bullets[2]));
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

	IEnumerator fire(float rate, Rigidbody b){
		//getting mouse position with raycasting
		Ray ray = Camera.main.ScreenPointToRay(reticle.transform.position);
		Quaternion rotation = Quaternion.LookRotation(ray.direction);
		
		//Instantiating the bullet and giving it force to move
		Rigidbody instance = Instantiate(b,Camera.main.transform.position,rotation*b.transform.rotation) as Rigidbody;
		if (a != null)
			a.Play ();
		instance.AddForce(ray.direction*force, forceMode);
		instance.transform.SetParent (transform);
		
		//telling the gun not to fire after initial shot
		canFire = false;
		
		//if the gun has ammo, subtract ammo from the total
		if (ammo > 0)
			ammo--;
		
		//wait for however long the rate of fire is in seconds
		yield return new WaitForSeconds (rate);
		
		//if there is no more ammo, switch back to the pistol
		if (ammo == 0) {
			reloadText.SetActive (true);
			gunType = 0;
			reticle.sprite = sprites[0];
			ammoScale = 5;
		}
		else {
			canFire = true;
			reloadText.SetActive (false);
		}

		ChangeIcon ();
	}

	//changes the icon on the lower part of the HUD to represent the currently selected gun
	void ChangeIcon(){
		switch (gunType) {
		case 0:
			gunIcons[0].sprite = sprites[3];
			gunIcons[1].sprite = sprites[7];
			gunIcons[2].sprite = sprites[8];
			break;
		case 1:
			gunIcons[0].sprite = sprites[6];
			gunIcons[1].sprite = sprites[4];
			gunIcons[2].sprite = sprites[8];
			break;
		case 2:
			gunIcons[0].sprite = sprites[6];
			gunIcons[1].sprite = sprites[7];
			gunIcons[2].sprite = sprites[5];
			break;
		default:
			break;
		}
	}
}
