using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MovingPlatform : MonoBehaviour {

	public AudioClip drowning;
	public AudioClip waterSound;
	AudioSource SoundSource;

	public float speed;
	public bool inMaze = false;
	public bool alive = true;
	public bool enteredMaze = false;
	public bool pulledLever = false;
	public bool moveDown = false;
	public bool slower = false;
	public bool stop = false;

    Vector3 SpawnPoint;
	FirstPersonController player;
	InMazeLevers lev;

//	public LeverFinished leverFirstRoom;
//	public LeverFinished leverSecondRoom;
//	public LeverFinished leverThirdRoom;

	void Start(){
		SoundSource = GetComponent<AudioSource> ();
		player = GameObject.Find ("FPSController").GetComponent<FirstPersonController>();
		SpawnPoint = new Vector3(-5f, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log ("Pulled " + pulledLever);
		//Debug.Log ("Am I in the maze? " + inMaze);
		//Debug.Log ("Am I alive? " + alive);
		//Debug.Log ("Have I entered the maze? " + enteredMaze);
		//Debug.Log ("Down ? " + moveDown);
		//Debug.Log("Slower? " + slower);



		if (inMaze && alive && !pulledLever) 
		{
			speed = 0.08f;
			transform.Translate (Vector3.up * speed * 1 * Time.deltaTime);
			enteredMaze = true;
			stop = false;
		}

		if ((!inMaze && alive && enteredMaze && !stop) || (pulledLever && enteredMaze && !stop && alive)) 
		{
			speed = 0.2f;
			transform.Translate (Vector3.up * speed * -1 * Time.deltaTime);
		}



	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			SoundSource.PlayOneShot(waterSound, 0.005f);
			inMaze = true;
			enteredMaze = true;
			moveDown = false;
		}

		if(other.tag == "Slower")
		{
			player.m_WalkSpeed = 3.5f;
		}

		if (other.tag == "UpperLimit") 
		{
			SoundSource.PlayOneShot (drowning, 0.4f);
			alive = false;

//			if (leverFirstRoom.closed == true && leverSecondRoom.closed == true && leverThirdRoom == true) 
//			{
//				Debug.Log ("Trzeci");
//				SpawnPoint = new Vector3(81, -2.7f, 16);
//				player.transform.position = SpawnPoint;	
//			}
//			else if (leverFirstRoom.closed == true && leverSecondRoom.closed == true)
//			{
//				Debug.Log ("Drugi");
//			    player.transform.position = SpawnPoint;	
//			}
//			else if (leverFirstRoom.closed == true)
//			{
//				Debug.Log ("Pierwszy");
//				player.transform.position = SpawnPoint;	
//				SpawnPoint = new Vector3(110, -2.7f, 16);
//			}
//			else
//				Debug.Log ("Zaden");
					

		} 
		else if (other.tag == "LowerLimit") 
		{	
			stop = true;
			moveDown = false;
			enteredMaze = false;
		}
		
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			moveDown = true;
			inMaze = false;
		}

		if(other.tag == "Slower")
		{
			player.m_WalkSpeed = 5.0f;

		}
	
	}		
}
	
