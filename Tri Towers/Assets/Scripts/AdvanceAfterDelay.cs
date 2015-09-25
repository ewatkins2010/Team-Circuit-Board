using UnityEngine;
using System.Collections;

public class AdvanceAfterDelay : MonoBehaviour
{
	public NodeMovement playerNodeMovement;
	public float delay = 1.0f;

	void Start()
	{
		Invoke ("Advance", delay);
	}

	void Advance()
	{
		if(playerNodeMovement == null)
		{
			playerNodeMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<NodeMovement>();
		}
		
		playerNodeMovement.MoveToNextNode();
	}
}
