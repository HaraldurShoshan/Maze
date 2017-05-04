using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour {

	private Animator anim = null;
	private Animator doorAnim = null;
	private bool lever;
	private bool openDoor;
	private GameObject mainDoor;
	// Use this for initialization
	void Start () {
		lever = false;
		openDoor = false;
		anim = GetComponent<Animator> ();
		mainDoor = GameObject.Find ("Door");
		doorAnim = mainDoor.GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider col)
	{
		lever = true;
	}

	void OnTriggerExit(Collider col)
	{
		lever = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f") && lever && !openDoor) {
			Debug.Log ("if");
			openDoor = true;
			anim.SetBool ("open", true);
			doorAnim.SetBool ("isOpen", true);

		} else if (Input.GetKeyDown ("f") && lever && openDoor) 
		{
			Debug.Log ("else");
			openDoor = false;
			anim.SetBool ("open", false);
			doorAnim.SetBool ("isOpen", false);
		}
	}
}
