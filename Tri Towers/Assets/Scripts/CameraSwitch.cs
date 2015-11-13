using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
	public GameObject[] cameras;
	public float[] delays;
	int index;

	// Use this for initialization
	void Start () {
		index = 0;
		StartCoroutine (SwitchView (delays[index]));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SwitchView(float d){
		yield return new WaitForSeconds (d);
		cameras [index].SetActive (false);

		if ((index + 1) < cameras.Length) {
			cameras[index+1].SetActive (true);
			StartCoroutine (SwitchView (delays[index+1]));
		}
	}
}
