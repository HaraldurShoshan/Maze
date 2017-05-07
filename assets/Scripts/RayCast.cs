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
	RaycastHit lastHit;

	GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

		if (Physics.Raycast (this.transform.position, this.transform.forward, out whatIHit, distanceToSee)) {

			GameObject nowHitByRay = whatIHit.collider.gameObject;

			if (lastHitByRay && lastHitByRay != nowHitByRay) {
				lastHitByRay.SendMessage ("OnRayHitEnded");
			}

			lastHitByRay = nowHitByRay;
			nowHitByRay.SendMessage ("OnRayHitBegan");


//			if (nowHitByRay.tag == "LeverNewDoor") {
//				Debug.Log (nowHitByRay.gameObject.tag);
//				nowHitByRay.SendMessage ("OnRayHitBegan");
//			}

			



//			whatIHit.transform.SendMessage("OnRayHitBegan");
//			nowHitByRay.transform.SendMessage ("OnRayHitBegan");
//
//			if (lastHitByRay && lastHitByRay != nowHitByRay) {
//				lastHitByRay.transform.SendMessage ("OnRayHitEnded");
//			} else {
//				lastHitByRay = nowHitByRay;
//				nowHitByRay.SendMessage("OnRayHitBegan");
//			}

//			if (lastHitByRay && lastHitByRay != nowHitByRay) {
//				lastHitByRay.SendMessage ("hitByRayEnded");
//			}
//
//			lastHitByRay = nowHitByRay;
//			nowHitByRay.SendMessage ("hitByRay");
//			whatIHit.transform.SendMessage ("HitByRay");


		} else {
			if (lastHitByRay) {
				lastHitByRay.SendMessage ("OnRayHitEnded");
			}
		}
	}
}
