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

		if ((index + 1) < cameras.Length) {
			cameras[index+1].SetActive (true);
			cameras [index].SetActive (false);
			index++;
			StartCoroutine (SwitchView (delays[index]));
			AnimationTrigger.indexCheck = index;
		}
	}
}
