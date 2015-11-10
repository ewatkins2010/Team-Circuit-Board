using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	//hotspot is the center of the reticle
	public Sprite[] sprites;
	public GameObject[] shields;
	public Image[] gunIcons;

	[HideInInspector]public int shieldHit;
	[HideInInspector]public bool canShield;
	public float ammoScale;

	//tells the gun if it can fire or not;
	bool canFire;
	CursorMove playerNumber;
	AudioSource a, r;
	int shieldIndex;
	
	// Use this for initialization
	void Start ()
	{
		playerNumber = GetComponent<CursorMove> ();
		a = GameObject.Find ("Player Fire").GetComponent<AudioSource> ();
		r = GameObject.Find ("Reload").GetComponent<AudioSource> ();
		canFire = true;
		canShield = true;
		ammo = 5;
		ammoScale = 5;
		shieldHit = 0;

		if (playerNumber.solo)
			shieldIndex = 1;
		else
			shieldIndex = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ammoBar != null)
			ammoBar.GetComponent<RectTransform> ().localScale = new Vector3 (1, ammo / ammoScale, 1);

	}

	public void Shield(string button){
		if (shieldHit >= 3) {
			canShield = false;
			StartCoroutine ("Recharge");
		}
		if (shields [shieldIndex] != null) {
			if (canShield && Input.GetButton (button)) {
				shields [shieldIndex].SetActive (true);
			} else {
				shields [shieldIndex].SetActive (false);
			}
		}
	}

	public IEnumerator Recharge(){
		shieldIcon.GetComponent<Animator> ().SetBool ("Fade", true);
		yield return new WaitForSeconds (10f);
		shieldIcon.GetComponent<Animator> ().SetBool ("Fade", false);
		canShield = true;
		shieldHit = 0;
	}

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
		//ammoDisplay.text = ammo + "";
		//if the gun can fire, then shoot
		if (canFire){
			switch (gunType){
				//this is the pistol
			case 0:
				reticle.sprite = sprites[0];
				if (Input.GetButtonDown (button))
					StartCoroutine (fire (.3f, bullets[0], 1f));
				break;
				//this is the rifle, it has a faster rate of fire
			case 1:
				reticle.sprite = sprites[1];
				if (Input.GetButton (button))
					StartCoroutine (fire (.1f, bullets[1], 1f));
				break;
				//this is the shot gun. it uses the BigBullet and has a slower rate of fire
			case 2:
				reticle.sprite = sprites[2];
				if (Input.GetButtonDown (button))
					StartCoroutine (fire (1f, bullets[2], 1.3f));
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
		Rigidbody instance = Instantiate(b,Camera.main.transform.position,rotation*b.transform.rotation) as Rigidbody;
		if (a != null)
			a.Play ();
		instance.AddForce(ray.direction*force*boost, forceMode);
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
		}

		ChangeIcon ();
	}

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
