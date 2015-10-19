using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cutscenes : MonoBehaviour {
	public MovieTexture scene;
	public AudioSource music;
	// Use this for initialization
	void Start () {
		GetComponent<RawImage>().texture = scene;
		music.clip = scene.audioClip;
		scene.Play ();
		music.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!scene.isPlaying)
			Application.LoadLevel (Application.loadedLevel + 1);
	}
}
