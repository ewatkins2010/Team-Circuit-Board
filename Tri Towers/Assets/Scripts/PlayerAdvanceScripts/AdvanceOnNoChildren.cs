using UnityEngine;
using System.Collections;

public class AdvanceOnNoChildren : MonoBehaviour
{
	public NodeMovement playerNodeMovement;
	
	void Update ()
	{
		if (transform.childCount <= 0) 
		{
			if (playerNodeMovement == null) 
				playerNodeMovement = GameObject.FindGameObjectWithTag ("Player").GetComponent<NodeMovement> ();
			if (gameObject.tag == "Left")
				playerNodeMovement.MoveToAltNode ();
			else
				playerNodeMovement.MoveToNextNode ();

			Destroy (gameObject);
		}
	}
}