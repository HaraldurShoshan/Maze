using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialBox : MonoBehaviour {
	private bool display;
	Canvas tutCan;

	TutorialText tt;
	// Use this for initialization
	void Start () {
		tutCan = GameObject.Find ("PullFirstLever").GetComponent<Canvas> ();
		tt = tutCan.GetComponent<TutorialText> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player") && !display) {
			tt.display = true;
			display = true;
		}

	}
}
