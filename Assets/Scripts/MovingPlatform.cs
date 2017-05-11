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
	public bool alive = true;
	public bool pulledLever = false;
	public bool moveDown = false;
	public bool slower = false;
	public bool stop = false;
	public bool rising = false;

	FirstPersonController player;

	void Start(){
		SoundSource = GetComponent<AudioSource> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (rising) 
		{
			speed = 0.1f;
			transform.Translate (Vector3.up * speed * 1 * Time.deltaTime);
			stop = false;
		}

		if (!rising && !stop)
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

		} 
		else if (other.tag == "LowerLimit") 
		{	
			stop = true;
			moveDown = false;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			moveDown = true;
		}

		if(other.tag == "Slower")
		{
			player.m_WalkSpeed = 5.0f;
		}	
	}		
}
	
