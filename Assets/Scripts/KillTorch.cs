using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTorch : MonoBehaviour {

	public bool fireOff;

	// Use this for initialization
	void Start () {
		fireOff = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (fireOff) {
			gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag ("Water")) {
			fireOff = true;
		}
	}
}
