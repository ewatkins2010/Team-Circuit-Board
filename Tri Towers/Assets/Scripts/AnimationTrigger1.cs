using UnityEngine;
using System.Collections;

public class AnimationTrigger1 : MonoBehaviour {
	public Animator First2;
	public Animator Second2;
	public Animator Third2;
	public Animator Fourth2;
	public static int indexCheck1;
	/*public Animator Fifth;
	public Animator Sixth;
	public Animator Seventh;
	*/
	// Use this for initialization
	void Start () {
		First2.enabled = false;
		Second2.enabled = false;
		Third2.enabled = false;
		Fourth2.enabled = false;
		//Fifth.enabled = false;
	///	Sixth.enabled = false;
		//Seventh.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		print (indexCheck1);
		if (indexCheck1 == 3) 
			First2.enabled = true;
		if (indexCheck1 == 4)
			Second2.enabled = true;
		if (indexCheck1 == 4)
			Third2.enabled = true;
		if (indexCheck1 == 5)
			Fourth2.enabled = true;
		/*if (indexCheck == 8)
			Fifth.enabled = true;
		if (indexCheck == 9)
			Sixth.enabled = true;
		if (indexCheck == 5)
			Seventh.enabled = true;*/

	}
}
