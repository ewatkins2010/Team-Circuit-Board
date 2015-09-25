using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

	public Node nextNode;
	public bool resetCamera;
	
	void OnDrawGizmos () 
	{
		if (nextNode != null) 
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine (transform.position, nextNode.transform.position);
		}
	}
}
