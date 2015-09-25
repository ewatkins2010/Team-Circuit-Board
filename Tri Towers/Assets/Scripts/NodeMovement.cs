using UnityEngine;
using System.Collections;

public class NodeMovement : MonoBehaviour {

	public Node currentNode; //This is the current node that the player is located at.
	public float movementSpeed = 20.0f; //The speed the player moves between nodes.
	public float rotationSpeed = 90.0f; //The speed the player rotates to follow the node path.
	public Transform head;

	public void MoveToNextNode()
	{
		currentNode = currentNode.nextNode;
		StartCoroutine (RotateToGoal(true));
	}

	//Rotate the camera towards the next node.
	IEnumerator RotateToGoal(bool initialRotation)
	{
		Quaternion goalRotation;
		if(initialRotation)
		{
			goalRotation = Quaternion.LookRotation(currentNode.transform.position-transform.position);
		}
		else 
		{
			goalRotation = currentNode.transform.rotation;
		}

		while (true) 
		{
			transform.rotation = Quaternion.RotateTowards (transform.rotation, goalRotation, rotationSpeed * Time.deltaTime);

			if(currentNode.resetCamera)
			{
				head.rotation = Quaternion.RotateTowards (head.rotation, Quaternion.identity, rotationSpeed * Time.deltaTime);
			}
			if (transform.rotation != goalRotation)
			{
				if(currentNode.resetCamera == false || head.rotation != Quaternion.identity)
					{
						yield return null;
					}
			}
			else
			{
				break;
			}
		}

		if (initialRotation) 
		{
			StartCoroutine (MoveToGoal());
		}
		else
		{
			foreach(Transform child in currentNode.transform)
			{
				child.gameObject.SetActive(true);
			}
		}
	}

	//Move the player towards the next node.
	IEnumerator MoveToGoal()
	{
		while (true) 
		{
			transform.position += transform.forward * movementSpeed * Time.deltaTime;

			if (Vector3.Dot (transform.forward, currentNode.transform.position - transform.position) <= 0) 
			{
				transform.position = currentNode.transform.position;
				break;
			}
			yield return null;
		}

		StartCoroutine (RotateToGoal(false));
	}
}