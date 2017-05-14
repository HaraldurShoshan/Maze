using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : MonoBehaviour {
	public AudioClip closeDoor;
	AudioSource audio;
	public bool finish;
	private bool oneTime;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (finish && !oneTime) {
			oneTime = true;
			audio.PlayOneShot (closeDoor, 0.5f);
		}
	}
}
