using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public float health;
    //public static bool isPlayerAlive = true;
	
	void Start () {
	
	}
	
	
	void Update () {
	
        if(health < 0f)
        {
            Destroy(gameObject);
        }
	}
}
