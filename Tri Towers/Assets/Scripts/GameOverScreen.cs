using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
	public GameObject p1,p2;
	public string deadPlayer;
	public GameObject button;

	public bool testing, solo;
	GameData data;
	Vector3 temp;
	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		if (!testing) {
			data = GameObject.Find ("GameData").GetComponent<GameData>();
			deadPlayer = data.died;
			solo = data.alone;
		}

		if (solo) {
			p2.SetActive (false);
			p1.GetComponent<Animator> ().SetTrigger ("Dead");
			StartCoroutine ("ShowButton");
		} 
		else {
			switch (deadPlayer) {
			case "Player1":
				p1.GetComponent<Animator> ().SetTrigger ("Dead");
				p2.GetComponent<Animator> ().SetTrigger ("Sad");
				temp = p1.transform.position;
				temp.x -= 3f;
				p1.transform.position = temp;
				StartCoroutine ("ShowButton");
				break;
			case "Player2":
				p1.GetComponent<Animator> ().SetTrigger ("Sad");
				p2.GetComponent<Animator> ().SetTrigger ("Dead");
				temp = p2.transform.position;
				temp.x -= 4f;
				p2.transform.position = temp;
				StartCoroutine ("ShowButton");
				break;
			default:
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ShowButton(){
		yield return new WaitForSeconds (3f);
		button.SetActive (true);
	}

	public void Retry(){
		Application.LoadLevel (data.nextLevel);
	}

	public void Quit(){
		Application.Quit ();
	}
}
