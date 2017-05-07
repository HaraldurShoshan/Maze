using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public AudioClip drowning;
	AudioSource SoundSource;
	public float volume;

	public float speed;
	private bool inMaze = false;
	private bool alive = true;
	private bool enteredMaze = false;

	void Start(){
		SoundSource = GetComponent<AudioSource> ();
		volume = 0.4f;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Am I in the maze? " + inMaze);
		Debug.Log ("Am I alive? " + alive);
		Debug.Log ("Have I entered the maze? " + enteredMaze);

		if (inMaze && alive) 
		{
			speed = 0.05f;
			transform.Translate (Vector3.up * speed * 1 * Time.deltaTime);
		}

		if (!inMaze && alive && enteredMaze) 
		{
			speed = 0.2f;
			transform.Translate (Vector3.up * speed * -1 * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			inMaze = true;
			enteredMaze = true;
		}

	
		if (other.tag == "UpperLimit") 
		{
			SoundSource.PlayOneShot (drowning, volume);
			alive = false;
		} 
		else if (other.tag == "LowerLimit") 
		{	
			enteredMaze = false;
		}
		
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			inMaze = false;
		}
	
	}		
}
	
