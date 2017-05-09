using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMazeLevers : MonoBehaviour {

	public bool hit;
	private bool waitForAnim;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (hit) {
			Debug.Log ("LEVER WAS HIT");
		}

		if (Input.GetKeyDown ("e") && hit && !waitForAnim) {
//			anim.SetBool ("pulled", true);
			waitForAnim = true;
			anim.SetTrigger ("pully");
			StartCoroutine (animationWait ());
		}
	}

	IEnumerator animationWait(){

		yield return new WaitForSeconds (12);
		waitForAnim = false;
	}
}
