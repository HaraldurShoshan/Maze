using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingPlatform : MonoBehaviour {

	public AudioClip drowning;
	AudioSource SoundSource;
	public float volume;

	public float speed;
	private bool inMaze = false;
	private bool alive = true;
	private bool enteredMaze = false;

//	Vector3 SpawnPoint;
//	GameObject player;

	void Start(){
		SoundSource = GetComponent<AudioSource> ();
		volume = 0.4f;
//		player = GameObject.FindWithTag("Player");
//		SpawnPoint = new Vector3(-5f, 0, 0);
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
//			if (player.transform.position.x > 85f)
//				SceneManager.LoadScene ("JanekTest");
//			else if(player.transform.position.x > 96f || player.transform.position.x < 85f)
//				player.transform.position = SpawnPoint;
			
			
		
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
	
