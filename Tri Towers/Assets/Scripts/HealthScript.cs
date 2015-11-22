using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	//making a slider for testing in the inspector
	[Range(0,200)]
    public float health;
	public int score;

	public GameObject bar;

	float healthMax;
    //public static bool isPlayerAlive = true;
	
	void Start () {
		score = 0;
		if (GetComponent<CursorMove> ().solo) {
			health = 200f;
			healthMax = 200f;
		}
		else {
			health = 100f;
			healthMax = 100f;
		}
	}
	
	
	void Update () {
		//adjusting the bar based on the health value
		if (bar!=null)
			bar.GetComponent<RectTransform>().localScale = new Vector3(1,health/healthMax,1);
		//keeping the health between 0 and 100
		if (health > healthMax)
			health = healthMax;
		if (health < 0) {
			health = 0;
			Camera.main.GetComponent<Pause>().Restart ();
		}
	}
}
