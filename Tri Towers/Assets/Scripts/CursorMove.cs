using UnityEngine;
using System.Collections;

public class CursorMove : MonoBehaviour {
	public float speed;
	public bool p1, p2, solo;

	Shoot playerShoot;
	Vector3 movement = Vector3.zero;
	int numControllers;

	// Use this for initialization
	void Start () {
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
				if (solo) {
					ControllerMove1 ();
				}
				else {
					MouseMove ();
				}
				break;
			case 2:
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

	/*void Shoot(){
		Ray ray = Camera.main.ScreenPointToRay (transform.position);
		Quaternion rotation = Quaternion.LookRotation(ray.direction);
		GameObject instance = Instantiate (bullet,Camera.main.transform.position, rotation) as GameObject;
		instance.GetComponent<Rigidbody> ().AddForce (ray.direction * 50f, force);
	}*/

	void ControllerMove1(){
		movement.x = Input.GetAxis ("Horizontalp1") * speed * Time.deltaTime;
		movement.y = Input.GetAxis ("Verticalp1") * speed * Time.deltaTime;

		transform.position += movement;
		
		Vector3 temp = GetComponent<RectTransform>().position;
		temp.x = Mathf.Clamp (temp.x, 0, Screen.width);
		temp.y = Mathf.Clamp (temp.y, 0, Screen.height);
		GetComponent<RectTransform>().position = temp;

		playerShoot.CheckGun ("Firep1");
	}

	void ControllerMove2(){
		movement.x = Input.GetAxis ("Horizontalp2") * speed * Time.deltaTime;
		movement.y = Input.GetAxis ("Verticalp2") * speed * Time.deltaTime;

		transform.position += movement;
		
		Vector3 temp = transform.position;
		temp.x = Mathf.Clamp (temp.x, 0, Screen.width);
		temp.y = Mathf.Clamp (temp.y, 0, Screen.height);
		transform.position = temp;

		playerShoot.CheckGun ("Firep2");
	}
	
	void MouseMove() {
		transform.position = Input.mousePosition;
		playerShoot.CheckGun ("Firep1M");
	}
}
