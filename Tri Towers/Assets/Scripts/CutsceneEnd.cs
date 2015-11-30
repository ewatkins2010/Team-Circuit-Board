using UnityEngine;
using System.Collections;

public class CutsceneEnd : MonoBehaviour {
	public float delay;
	public int level;
	// Use this for initialization
	void Start () {
		StartCoroutine ("NextScene");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel (level);
		}
	}

	public IEnumerator NextScene(){
		yield return new WaitForSeconds (delay);
		Application.LoadLevel (level);
	}
}
