using UnityEngine;
using System.Collections;

public class CursorMove : MonoBehaviour {
	public float speed;
	public bool p1, p2, solo, testing, lightGun;
	public GameObject cursor;

	GameData data;
	Shoot playerShoot;
	Vector3 movement = Vector3.zero;
	int numControllers;

	// Use this for initialization
	void Awake () {
		if (!testing) {
			data = GameObject.Find ("GameData").GetComponent<GameData> ();
			solo = data.alone;
			if(p1)
				data.CheckPlayers ();
		}
		playerShoot = GetComponent<Shoot> ();
		numControllers = Input.GetJoystickNames().Length;
		Debug.Log (numControllers);
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		CheckControls (p1, p2);
	}

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
	
	void MouseMove() {
		cursor.transform.position = Input.mousePosition;
		playerShoot.CheckGun ("Firep1M");
		if (!lightGun) {
			playerShoot.Reload ("ReloadM");
			playerShoot.Shield ("ShieldM");
		}
		else {
			playerShoot.Reload ("LightgunReload1");
			playerShoot.Shield ("LightgunShield1");
		}
	}
}
