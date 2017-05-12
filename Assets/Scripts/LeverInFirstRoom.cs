using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInFirstRoom : MonoBehaviour {

	private Animator anim;
	private Animator doorAnim;
	public bool hit;
	public bool isOpen;
	torchCountMission mission;
	GameObject Tcount;
	string leverHitText;

	MovingPlatform water;

	// Use this for initialization
	void Start () {
		mission = GetComponent<torchCountMission> ();
		anim = GetComponent<Animator> ();
		leverHitText = "Press 'e' to use lever";
		water = GameObject.FindGameObjectWithTag ("Water").GetComponent<MovingPlatform> ();



	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "door") {
			doorAnim = other.gameObject.GetComponent<Animator> ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (mission.missionAccomplished) {
		
			Debug.Log ("Now you can Open the door");
		
		
			if (Input.GetKeyDown ("e") && hit && !isOpen) {
				water.rising = true;
				water.stop = false;
				anim.SetBool ("isOpen", true);
				doorAnim.SetBool ("isOpen", true);
				StartCoroutine (animationWait ());
			} else if (Input.GetKeyDown ("e") && hit && isOpen) {
				water.rising = false;
				anim.SetBool ("isOpen", false);
				doorAnim.SetBool ("isOpen", false);
				StartCoroutine (animationWait ());
			}
		}
	}

	void OnGUI()
	{
		if (hit && mission.missionAccomplished)
			GUI.Box (new Rect( ((Screen.width / 2)-100) , Screen.height / 2, 200, 22), leverHitText);
		else if(hit && !mission.missionAccomplished)
			GUI.Box (new Rect( ((Screen.width / 2)-100) , Screen.height / 2, 200, 22), "Light all the torches first");
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
