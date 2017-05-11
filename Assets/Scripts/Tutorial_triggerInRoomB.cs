using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_triggerInRoomB : MonoBehaviour {

	private bool display;
	Canvas tutCan;

	Tutorial_leverInRoomB tt;
	// Use this for initialization
	void Start () {
		tutCan = GameObject.Find ("PullLeverInRoomBetweenTutorial").GetComponent<Canvas> ();
		tt = tutCan.GetComponent<Tutorial_leverInRoomB> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player") && !display) {
			tt.display = true;
			display = true;
		}
	}
}
