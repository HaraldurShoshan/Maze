using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMazeLevers : MonoBehaviour {

	public bool hit;
	private bool waitForAnim;
	private Animator anim;

	MovingPlatform water;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		water = GameObject.Find ("Water").GetComponent<MovingPlatform> ();
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Input.GetKeyDown ("e") && hit && !waitForAnim) 
		{
			water.rising = false;

			waitForAnim = true;
			anim.SetTrigger ("pully");
			StartCoroutine (leverWait ());
			StartCoroutine (animationWait ());
		}
	}

	IEnumerator animationWait()
	{
		yield return new WaitForSeconds (7);
		water.rising = true;
		waitForAnim = false;
	}


	IEnumerator leverWait()
	{
		yield return new WaitForSeconds (7);
		water.rising = true;
		water.stop = false;
	}


}
