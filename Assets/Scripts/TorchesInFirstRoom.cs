﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchesInFirstRoom : MonoBehaviour {

	public bool hit;
	public bool fireOff;
	public bool fireIsOn;
	string lightOn;	
	GameObject myFire;
	public Canvas text;

	void Start() {
		fireIsOn = false;
		lightOn = "Press 'e' to turn on torches";
		text.GetComponent<Canvas> ();
		text.enabled = false;
	}
		
	void Update() {
		if (!fireIsOn) 
		{
			myFire.SetActive (false);
		}			

		if (hit) {
			if (!myFire.activeSelf) {
				text.enabled = true;
			}

			if (Input.GetKeyDown ("e") && !myFire.activeSelf) {
				myFire.SetActive (true);
				fireIsOn = true;
			}
		} else {
			text.enabled = false;
		}			
	}

//	void OnGUI()
//	{
//		if (hit && !fireIsOn) {
//			GUI.Box (new Rect (((Screen.width / 2) - 100), Screen.height / 2, 200, 22), lightOn);
//		}
//	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Fire") && !myFire) 
		{
			myFire = other.gameObject;
		}
	}
}
