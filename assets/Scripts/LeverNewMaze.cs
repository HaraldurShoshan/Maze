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
		leverHitText = "Press 'e' to use lever";
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
			StartCoroutine(animationWait ());
//			isOpen = true;
		} else if (Input.GetKeyDown ("e") && hit && isOpen) {
			anim.SetBool ("isOpen", false);
			doorAnim.SetBool ("isOpen", false);
			StartCoroutine(animationWait ());
//			isOpen = false;
		}
	}
			
	void OnGUI()
	{
		if (hit)
			GUI.Box (new Rect( ((Screen.width / 2)-100) , Screen.height / 2, 200, 22), leverHitText);
	}

	IEnumerator animationWait(){
		
		yield return new WaitForSeconds (4);
		if (isOpen) {
			Debug.Log ("true");
			isOpen = false;
		} else {
			Debug.Log ("false");
			isOpen = true;
		}
	}


}
