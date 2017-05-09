﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchesInFirstRoom : MonoBehaviour {

	public bool hit;
	public bool fireOff;
	public bool fireIsOn;
	string lightOn;
	GameObject myFire;

	void Start() {
		fireOff = false;
		hit = false;
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
				fireIsOn = true;

			}

			if (Input.GetKeyDown ("q") && fireOff) 
			{
				fireOff = false;
			}
		}

	}

	void OnGUI()
	{
		if (hit && !fireIsOn) {
			GUI.Box (new Rect (((Screen.width / 2) - 100), Screen.height / 2, 200, 22), lightOn);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Fire") && !myFire) {
			myFire = other.gameObject;
		}
	}
}