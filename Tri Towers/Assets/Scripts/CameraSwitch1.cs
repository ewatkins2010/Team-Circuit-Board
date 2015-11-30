using UnityEngine;
using System.Collections;

public class CameraSwitch1 : MonoBehaviour {
	public GameObject[] cameras;
	public float[] delays;
	int index2;

	// Use this for initialization
	void Start () {
		index2 = 0;
		StartCoroutine (SwitchView (delays[index2]));
	}
	
	// Update is called once per frame
	void Update () {
		//print (index);
	}

	IEnumerator SwitchView(float d){
		yield return new WaitForSeconds (d);

		if ((index2 + 1) < cameras.Length) {
			cameras[index2+1].SetActive (true);
			cameras [index2].SetActive (false);
			index2++;
			StartCoroutine (SwitchView (delays[index2]));
			AnimationTrigger1.indexCheck1 = index2;
		}
	}
}
