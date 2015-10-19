using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	//making a slider for testing in the inspector
	[Range(0,100)]
    public float health;

	public GameObject bar;
    //public static bool isPlayerAlive = true;
	
	void Start () {

	}
	
	
	void Update () {
		//adjusting the bar based on the health value
		if (bar!=null)
			bar.GetComponent<RectTransform>().localScale = new Vector3(1,health/100f,1);

		//keeping the health between 0 and 100
		if (health > 100)
			health = 100;
		if (health < 0) {
			health = 0;
			Camera.main.GetComponent<Pause>().Restart ();
		}
	}
}
