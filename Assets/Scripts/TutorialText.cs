using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour {
	private Canvas myCanvas;
	public bool display;
	// Use this for initialization
	void Start () {
		myCanvas = GetComponent<Canvas>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (display) {
			myCanvas.enabled = true;
			StartCoroutine (displayText ());

		} else if (!display) {
			myCanvas.enabled = false;
		}
	}

	IEnumerator displayText(){

		yield return new WaitForSeconds (5);
		display = false;
	}
}
