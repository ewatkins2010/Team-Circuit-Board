using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
	public GameObject p1, p2;
	public GameObject p1Text, p2Text, button;

	public bool testing, solo;
	public int max1, max2;

	public Text p1ScoreText, p2ScoreText;
	public AudioSource a, b;

	int p1Score, p2Score;
	GameData data;



	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		if (!testing) {
			data = GameObject.Find ("GameData").GetComponent<GameData> ();
			max1 = data.score1;
			max2 = data.score2;
			solo = data.alone;
		}
		StartCoroutine ("ActivateScore");

		if (solo)
			p2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator ActivateScore(){
		yield return new WaitForSeconds (2f);
		p1Text.SetActive (true);
		if (!solo)
			p2Text.SetActive (true);
		StartCoroutine ("CountUP");
	}

	IEnumerator CountUP(){
		if (!a.isPlaying)
			a.Play ();
		p1Score+=15;
		p2Score+=15;
		yield return new WaitForSeconds (0f);

		p1Score = Mathf.Clamp (p1Score, 0, max1);
		p2Score = Mathf.Clamp (p2Score, 0, max2);

		p1ScoreText.text = p1Score + "";
		if(!solo)
			p2ScoreText.text = p2Score + "";

		if (p1Score < max1 || p2Score < max2) {
			StartCoroutine ("CountUP");
		} 
		else {
			a.Stop ();
			b.Play ();
			SetAnimations();
		}
	}

	void SetAnimations(){
		if (!solo) {
			if (p1Score > p2Score) {
				p1.GetComponent<Animator> ().SetTrigger ("Win");
				p2.GetComponent<Animator> ().SetTrigger ("Lose");
			} else {
				p1.GetComponent<Animator> ().SetTrigger ("Lose");
				p2.GetComponent<Animator> ().SetTrigger ("Win");
			}
		} else {
			p1.GetComponent<Animator> ().SetTrigger ("Win");
		}

		button.SetActive (true);
	}

	public void NextLevel(){
		Application.LoadLevel (data.nextLevel);
	}
}
