using UnityEngine;
using System.Collections;

//Edward Watkins
//Cursor Movement script for Tri Towers

public class CursorMove : MonoBehaviour {

	//inspector controlled variables
	public float speed;
	public bool p1, p2, solo, testing, lightGun;
	public GameObject cursor;


	GameData data;
	Shoot playerShoot;
	Vector3 movement = Vector3.zero;
	int numControllers;

	// Use this for initialization
	void Awake () {
		//for testing purposes I dont access the gamedata object and control these variables in the inspector
		if (!testing) {
			data = GameObject.Find ("GameData").GetComponent<GameData> ();
			solo = data.alone;
			if(p1)
				data.CheckPlayers ();
		}

		playerShoot = GetComponent<Shoot> ();

		//get the number of controllers to determine the control scheme
		numControllers = Input.GetJoystickNames().Length;
		Debug.Log (numControllers);

		//remove the cursor when playing the game
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		CheckControls (p1, p2);
	}

	//Control Schemes for solo and multiplayer
	//Scheme 1: 1 player uses the mouse
	//Scheme 2: 1 player uses the controller
	//Scheme 3: 1 player uses the lightgun
	//Scheme 4: 2 players with one on mouse and one on the controller
	//Scheme 5: 2 players with one on the lightgun and one on the controller
	//Scheme 6: 2 players with both on the controller
	void CheckControls(bool p1, bool p2){
		if (p1){
			switch (numControllers){
			case 0:
				MouseMove ();
				break;
			case 1:
				if (solo && !lightGun) {
					ControllerMove1 ();
				}
				else {
					MouseMove ();
				}
				break;
			case 2:
				if (lightGun)
					MouseMove ();
				else
					ControllerMove1 ();
				break;
			default:
				break;
			}
		}
		if (p2) {
			if (lightGun){
				ControllerMove2LG ();
			}
			else {
				switch (numControllers){
				case 1:
					ControllerMove1 ();
					break;
				case 2:
					ControllerMove2 ();
					break;
				}
			}
		}
	}

	//each of the below functions checks if the player is reloading, shielding, or shooting
	//function for player 1 movement
	void ControllerMove1(){
		movement.x = Input.GetAxis ("Horizontalp1") * speed * Time.deltaTime;
		movement.y = Input.GetAxis ("Verticalp1") * speed * Time.deltaTime;

		cursor.transform.position += movement;
		
		Vector3 temp = cursor.transform.position;
		temp.x = Mathf.Clamp (temp.x, 0, Screen.width);
		temp.y = Mathf.Clamp (temp.y, 0, Screen.height);
		cursor.transform.position = temp;

		playerShoot.CheckGun ("Firep1");
		playerShoot.Reload ("Reloadp1");
		playerShoot.Shield ("Shieldp1");
	}

	//function for player 2 movement
	void ControllerMove2(){
		movement.x = Input.GetAxis ("Horizontalp2") * speed * Time.deltaTime;
		movement.y = Input.GetAxis ("Verticalp2") * speed * Time.deltaTime;

		cursor.transform.position += movement;
		
		Vector3 temp = cursor.transform.position;
		temp.x = Mathf.Clamp (temp.x, 0, Screen.width);
		temp.y = Mathf.Clamp (temp.y, 0, Screen.height);
		cursor.transform.position = temp;

		playerShoot.CheckGun ("Firep2");
		playerShoot.Reload ("Reloadp2");
		playerShoot.Shield ("Shieldp2");
	}

	void ControllerMove2LG(){
		movement.x = Input.GetAxis ("Horizontalp2") * Screen.width * speed;
		movement.y = Input.GetAxis ("Verticalp2") * Screen.height * speed;
		
		cursor.transform.position = movement;
		
		Vector3 temp = cursor.transform.position;
		temp.x = Mathf.Clamp (temp.x, 0, Screen.width);
		temp.y = Mathf.Clamp (temp.y, 0, Screen.height);
		cursor.transform.position = temp;
		
		playerShoot.CheckGun ("LightgunFire2");
		playerShoot.Reload ("LightgunReload2");
		playerShoot.Shield ("LightgunShield2");
	}

	//function for mouse movement
	//the lightgun for player 1 also uses this function
	void MouseMove() {
		cursor.transform.position = Input.mousePosition;

		if (!lightGun) {
			playerShoot.CheckGun ("Firep1M");
			playerShoot.Reload ("ReloadM");
			playerShoot.Shield ("ShieldM");
		}
		else {
			playerShoot.CheckGun ("LightgunFire1");
			playerShoot.Reload ("LightgunReload1");
			playerShoot.Shield ("LightgunShield1");
		}
	}
}
