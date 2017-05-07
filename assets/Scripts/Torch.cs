using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {

	public bool hit;
	public bool fireOff;
	public Renderer rend;
	Rect rect;
	string lightOn;
	GameObject myFire;

	void Start() {
		fireOff = false;
		hit = false;
		rend = GetComponent<Renderer>();
		float size = Screen.width * 0.1f;
		rect = new Rect (Screen.width / 2 * size / 2, Screen.height * 0.7f, size, size);
		lightOn = "Press 'e' to turn on torches";
	}

	void OnRayHitBegan(){
		hit = true;
	}

	void OnRayHitEnded(){
		hit = false;
	}

	void Update() {

		if (!fireOff) 
		{
			myFire.SetActive (false);

		}

		if (hit) {
			

			if (Input.GetKeyDown ("e") && !fireOff) 
			{
				myFire.SetActive (true);
				fireOff = true;
			}

			if (Input.GetKeyDown ("q") && fireOff) 
			{
				fireOff = false;
			}
		}
			
	}

	void OnGUI()
	{
		if (hit)
			GUI.Box (new Rect(Screen.width / 2 , Screen.height / 2, 200, 22), lightOn);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Fire") && !myFire) {
			myFire = other.gameObject;
		}
	}
}
