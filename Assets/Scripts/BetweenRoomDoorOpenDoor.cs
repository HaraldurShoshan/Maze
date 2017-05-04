using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenRoomDoorOpenDoor : MonoBehaviour {

	public AudioClip closeDoor;
	AudioSource audio;
	public float Volume;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		Volume = 1f;
	}

	void OnTriggerExit(Collider col)
	{
		audio.PlayOneShot (closeDoor, Volume);
	}

	// Update is called once per frame
	void Update () {

	}
}
