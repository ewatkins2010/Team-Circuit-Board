using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public float health;
	public GameObject bar;
    //public static bool isPlayerAlive = true;
	
	void Start () {
	
	}
	
	
	void Update () {
		bar.GetComponent<RectTransform>().localScale = new Vector3(1,health/100f,1);
        if(health < 0f)
        {
            //Destroy(gameObject);
        }
	}
}
