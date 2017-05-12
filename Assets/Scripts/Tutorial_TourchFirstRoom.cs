using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_TourchFirstRoom : MonoBehaviour {

	private Canvas myCanvas;
	public bool display;
	// Use this for initialization
	void Start () {
		Debug.Log ("Testing");
		myCanvas = GetComponent<Canvas>();	
	}

	// Update is called once per frame
	void Update () {
		if (display) {
			Debug.Log ("on");
			myCanvas.enabled = true;
		} else if (!display) {
			myCanvas.enabled = false;
		}
	}
}
