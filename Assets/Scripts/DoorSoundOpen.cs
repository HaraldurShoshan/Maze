using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundOpen : MonoBehaviour {
	public AudioClip openDoor;
	AudioSource audio;
	public float Volume;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		Volume = 1f;
	}

	void OnTriggerEnter(Collider col)
	{
		audio.PlayOneShot (openDoor, Volume);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
