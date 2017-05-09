using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchesInFirstRoom : MonoBehaviour {

	public bool hit;
	public bool fireOff;
	public bool fireIsOn;
	string lightOn;
	GameObject myFire;

	void Start() {
		fireIsOn = false;
		lightOn = "Press 'e' to turn on torches";
	}
		
	void Update() {
		if (!fireIsOn) 
		{
			myFire.SetActive (false);
		}			

		if (hit) {
			if (Input.GetKeyDown ("e") && !myFire.activeSelf) 
			{
				myFire.SetActive (true);
				fireIsOn = true;
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
		if (other.gameObject.CompareTag ("Fire") && !myFire) 
		{
			myFire = other.gameObject;
		}
	}
}
