using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullLeverScript : MonoBehaviour {

	private Animator anim;
	private Animator doorNewAnim;
	private Animator doorOldAnim;
	public Transform DoorNewMaze;
	public bool lever;
	public bool doorIsOpen = true;

	private GameObject newDoor;
	private GameObject oldDoor;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		newDoor = GameObject.FindWithTag("door");
		doorNewAnim = newDoor.GetComponent<Animator> ();

		oldDoor = GameObject.FindWithTag ("oldDoor");
		doorOldAnim = oldDoor.GetComponent<Animator> ();

		lever = false;
	}

	void OnTriggerEnter(Collider other)
	{
		lever = true;

	}

	void OnTriggerExit(Collider other)
	{
		lever = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f") && lever && !doorIsOpen) {
			anim.Play ("PushLever");
			doorNewAnim.Play ("OpenDoor");
			doorOldAnim.Play ("OldDoorOpen");
			doorIsOpen = true;

		} else if (Input.GetKeyDown ("f") && lever && doorIsOpen) 
		{
			anim.Play ("PullLever");
			doorNewAnim.Play ("CloseDoor");
			doorOldAnim.Play ("OldDoorClose");
			doorIsOpen = false;
		}
			
		
	}
}
