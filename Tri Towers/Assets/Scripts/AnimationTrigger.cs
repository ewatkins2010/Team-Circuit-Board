using UnityEngine;
using System.Collections;

public class AnimationTrigger : MonoBehaviour {
	public Animator First;
	public Animator Second;
	public Animator Third;
	public Animator Fourth;
	public Animator Fifth;
	public Animator Sixth;
	public Animator Seventh;
	public static int indexCheck;
	// Use this for initialization
	void Start () {
		First.enabled = false;
		Second.enabled = false;
		Third.enabled = false;
		Fourth.enabled = false;
		Fifth.enabled = false;
		Sixth.enabled = false;
		Seventh.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (indexCheck == 1) 
			First.enabled = true;
		if (indexCheck == 2)
			Second.enabled = true;
		if (indexCheck == 3)
			Third.enabled = true;
		if (indexCheck == 7)
			Fourth.enabled = true;
		if (indexCheck == 8)
			Fifth.enabled = true;
		if (indexCheck == 9)
			Sixth.enabled = true;
		if (indexCheck == 5)
			Seventh.enabled = true;


	}
}
