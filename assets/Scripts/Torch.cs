using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {

	public bool hit;
	public bool fireOff;
	public bool fireIsOn;
	GameObject myFire;

	void Start() {
		fireIsOn = false;
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

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Fire") && !myFire) 
		{
			myFire = other.gameObject;
		}
	}
}
