using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float speed = 0.005f;
	private bool inMaze = false;
	private bool alive = true;
	private bool enteredMaze = false;
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Am I in the maze? " + inMaze);
		Debug.Log ("Am I alive? " + alive);
		Debug.Log ("Have I entered the maze? " + enteredMaze);
		if(inMaze && alive)
			transform.Translate (Vector3.up * speed * 1 * Time.deltaTime);
		if(!inMaze && alive && enteredMaze)
			transform.Translate (Vector3.up * speed * -1 * Time.deltaTime);
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
	
