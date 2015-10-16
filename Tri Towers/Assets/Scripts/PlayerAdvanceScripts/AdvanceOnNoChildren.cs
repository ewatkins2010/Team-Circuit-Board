using UnityEngine;
using System.Collections;

public class AdvanceOnNoChildren : MonoBehaviour
{
	public NodeMovement playerNodeMovement;
	
	void Update ()
	{
	//After the player has destroyed all the targets present, this sets the target node to move to.
		/*if(GameObject.FindGameObjectWithTag("Left").childCount <= 0)
		{
			if(playerNodeMovement == null)
			{
				playerNodeMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<NodeMovement>();
			}
			
			playerNodeMovement.MoveToAltNode();
			
			Destroy (gameObject);
		}*/

		if(transform.childCount <= 0)
		{
			if(playerNodeMovement == null)
			{
				playerNodeMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<NodeMovement>();
			}

			playerNodeMovement.MoveToNextNode();

			Destroy (gameObject);
		}
	}
}
