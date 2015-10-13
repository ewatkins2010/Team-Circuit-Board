using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {

	public Waypoints nextWaypoint;
	
	void OnDrawGizmos () 
	{
		if (nextWaypoint != null) 
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine (transform.position, nextWaypoint.transform.position);
		}
	}
}
