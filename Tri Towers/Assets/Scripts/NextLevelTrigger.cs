using UnityEngine;
using System.Collections;

public class NextLevelTrigger : MonoBehaviour {
	public bool testing;
	public int nextLevel;
	GameObject p1, p2;
	GameData data;
	// Use this for initialization
	void Start () {
		if (!testing) {
			data = GameObject.Find ("GameData").GetComponent<GameData>();
		}

		p1 = GameObject.Find ("P1");
		if (!p1.GetComponent<CursorMove> ().solo) {
			p2 = GameObject.Find ("P2");
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && !testing) {
			StartCoroutine("GoToScore");
		}
	}

	IEnumerator GoToScore(){
		yield return new WaitForSeconds(3f);
		data.nextLevel = nextLevel;
		data.score1 = p1.GetComponent<HealthScript>().score;
		if (p2 != null)
			data.score2 = p2.GetComponent<HealthScript>().score;
		
		Application.LoadLevel ("ScoreScreen");
	}
}
