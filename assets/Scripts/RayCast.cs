using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {
	public float distanceToSee;
	public Shader shader1;
	public Shader shader2;
	public Renderer rend;
	RaycastHit whatIHit;

	//torch
	GameObject torch;
	public Torch torchBool;

	//lever old door
	GameObject lever;
	public LeverFinished leverBool;

	//lever old door
	GameObject leverNew;
	public LeverNewMaze leverNewBool;

	GameObject lastHitByRay;

	GameObject player;

	TorchesInFirstRoom TorchNow;
	TorchesInFirstRoom TorchLast;

	Torch TorchMazeNow;
	Torch Torchmazelast;

	LeverInFirstRoom LIFRNow;
	LeverInFirstRoom LIFRLast;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

		if (Physics.Raycast (this.transform.position, this.transform.forward, out whatIHit, distanceToSee)) {

			GameObject nowHitByRay = whatIHit.collider.gameObject;

			if (nowHitByRay.gameObject.tag == "Torch") {
				TorchNow = nowHitByRay.gameObject.GetComponent<TorchesInFirstRoom> ();
//				ts.hit = true;

				if (TorchLast && TorchLast != TorchNow){
					TorchLast.hit = false;
				}

				TorchLast = TorchNow;
				TorchNow.hit = true;
			}

			if (nowHitByRay.gameObject.tag == "FirstRoomLever") {
				LIFRNow = nowHitByRay.gameObject.GetComponent<LeverInFirstRoom> ();

				if (LIFRLast && LIFRLast != LIFRNow) {
					LIFRLast.hit = false;
				}

				LIFRLast = LIFRNow;
				LIFRNow.hit = true;
			
			}
				



//			if (lastHitByRay && lastHitByRay != nowHitByRay) {
//				lastHitByRay.SendMessage ("OnRayHitEnded");
//			}
//
//			lastHitByRay = nowHitByRay;
//			nowHitByRay.SendMessage ("OnRayHitBegan");

		} 
		else {
			if (TorchLast) {
				TorchLast.hit = false;
			}
			if (LIFRLast) {
				LIFRLast.hit = false;
			}
		}
	}
}
