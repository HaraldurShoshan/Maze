using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverNewMaze : MonoBehaviour {

	private Animator anim;
	private Animator doorAnim;
	private bool showGUI;
	public bool hit;
	private bool isOpen;

	string leverHitText;

	// Use this for initialization
	void Start () {
		hit = false;
		showGUI = true;
		anim = GetComponent<Animator> ();
		leverHitText = "Press 'e' to pull lever down";
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
		if (Input.GetKeyDown ("e") && hit && !isOpen) {
			anim.SetBool ("isOpen", true);
			doorAnim.SetBool ("isOpen", true);
			isOpen = true;
		} else if (Input.GetKeyDown ("e") && hit && isOpen) {
			anim.SetBool ("isOpen", false);
			doorAnim.SetBool ("isOpen", false);
			isOpen = false;
		}
	}
			
	void OnGUI()
	{
		if (hit)
			GUI.Box (new Rect(Screen.width / 2 , Screen.height / 2, 200, 22), leverHitText);
	}
}
