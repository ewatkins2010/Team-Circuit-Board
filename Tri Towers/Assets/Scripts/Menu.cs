using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour {
	public List<GameObject> screens;
	public EventSystem selection;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < screens.Count; i++) {
			if (screens[i].gameObject.name != "Main")
				screens[i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChooseLevel(int lvl){
		Application.LoadLevel (lvl);
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void ChangeScreens(string label){
		for (int i = 0; i < screens.Count; i++) {
			if (screens[i].gameObject.name != label)
				screens[i].SetActive (false);
			else
				screens[i].SetActive (true);
		}
	}

}
