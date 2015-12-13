using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour {
	public List<GameObject> screens;
	public EventSystem selection;
	public Sprite[] images;
	public Image controls;
	// Use this for initialization
	void Start () {
		selection = GameObject.Find("EventSystem").GetComponent<EventSystem>();
		for (int i = 0; i < screens.Count; i++) {
			if (i == 0)
				screens[i].SetActive (true);
			else 
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
		selection.SetSelectedGameObject (GameObject.FindGameObjectWithTag("Button"));
	}

	public void ViewControls(int index){
		controls.sprite = images [index];
	}
}
