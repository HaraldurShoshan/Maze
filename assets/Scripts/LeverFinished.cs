using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFinished : MonoBehaviour {

	private Animator anim;
	private Animator doorAnim;
	private bool showGUI;
	public bool hit;
	public bool Levelfinished;


	MovingPlatform water;

	string leverHitText;

	// Use this for initialization
	void Start () {
		showGUI = true;
		anim = GetComponent<Animator> ();
		leverHitText = "Press 'e' to pull lever down";

		water = GameObject.FindGameObjectWithTag ("Water").GetComponent<MovingPlatform> ();
	}

	void OnRayHitBegan(){
		hit = true;
	}

	void OnRayHitEnded(){
		hit = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "door") {
			doorAnim = other.gameObject.GetComponent<Animator> ();
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("e") && hit) {
			water.rising = false;
			anim.SetBool ("isClosed", true);
			doorAnim.SetBool ("isClosed", true);
			showGUI = false;
			Levelfinished = true;
		}
	}

	void OnGUI()
	{
		if (hit && showGUI)
			GUI.Box (new Rect(Screen.width / 2 , Screen.height / 2, 200, 22), leverHitText);
	}
}
