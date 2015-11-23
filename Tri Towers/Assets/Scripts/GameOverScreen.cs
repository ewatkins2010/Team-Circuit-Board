using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
	public GameObject p1,p2;
	public string deadPlayer;
	public GameObject button;

	public bool testing;
	GameData data;
	Vector3 temp;
	// Use this for initialization
	void Start () {
		if (!testing) {
			data = GameObject.FindGameObjectWithTag ("GameData").GetComponent<GameData>();
			deadPlayer = data.died;
		}

		switch (deadPlayer) {
		case "Player1":
			p1.GetComponent<Animator>().SetTrigger ("Dead");
			p2.GetComponent<Animator>().SetTrigger ("Sad");
			temp = p1.transform.position;
			temp.x -= 3f;
			p1.transform.position = temp;
			StartCoroutine ("ShowButton");
			break;
		case "Player2":
			p1.GetComponent<Animator>().SetTrigger ("Sad");
			p2.GetComponent<Animator>().SetTrigger ("Dead");
			temp = p2.transform.position;
			temp.x -= 4f;
			p2.transform.position = temp;
			StartCoroutine ("ShowButton");
			break;
		default:
			break;
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
