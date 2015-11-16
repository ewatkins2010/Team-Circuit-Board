using UnityEngine;
using System.Collections;

public class EnemyWaves : MonoBehaviour {
	public GameObject nextWave;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount <= 0) {
			StartCoroutine("ActivateWave");
		}
	}

	IEnumerator ActivateWave(){
		yield return new WaitForSeconds (.5f);
		if(nextWave != null)
			nextWave.SetActive (true);
		Destroy (gameObject);
	}
}
