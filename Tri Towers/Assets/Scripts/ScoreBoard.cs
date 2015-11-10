using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
	public GameObject p1, p2;
	public GameObject p1Text, p2Text;

	public bool testing;
	public int max1, max2;

	public Text p1ScoreText, p2ScoreText;
	public int p1Score, p2Score;

	// Use this for initialization
	void Start () {
		StartCoroutine ("ActivateScore");
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator ActivateScore(){
		yield return new WaitForSeconds (2f);
		p1Text.SetActive (true);
		p2Text.SetActive (true);
		StartCoroutine ("CountUP");
	}

	IEnumerator CountUP(){
		p1Score++;
		p2Score++;
		yield return new WaitForSeconds (.005f);

		p1Score = Mathf.Clamp (p1Score, 0, max1);
		p2Score = Mathf.Clamp (p2Score, 0, max2);

		p1ScoreText.text = p1Score + "";
		p2ScoreText.text = p2Score + "";

		if (p1Score < max1 || p2Score < max2) {
			StartCoroutine ("CountUP");
		} 
		else {
			SetAnimations();
		}
	}

	void SetAnimations(){
		if (p1Score > p2Score) {
			p1.GetComponent<Animator>().SetTrigger("Win");
			p2.GetComponent<Animator>().SetTrigger("Lose");
		}
		else {
			p1.GetComponent<Animator>().SetTrigger("Lose");
			p2.GetComponent<Animator>().SetTrigger("Win");
		}
	}
}
