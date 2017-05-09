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

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

		if (Physics.Raycast (this.transform.position, this.transform.forward, out whatIHit, distanceToSee)) {

			GameObject nowHitByRay = whatIHit.collider.gameObject;

			if (whatIHit.collider.tag == "Fire") {
				Debug.Log ("Fires");
			}

			if (lastHitByRay && lastHitByRay != nowHitByRay) {

				try {
					lastHitByRay.SendMessage ("OnRayHitEnded");
				} catch (System.Exception ex) {
					Debug.Log (ex);
				}
			}

			lastHitByRay = nowHitByRay;
			try {
				nowHitByRay.SendMessage ("OnRayHitBegan");
			} catch (System.Exception ex) {
				Debug.Log (ex);
			}
				

		} else {
			if (lastHitByRay) {
				try {
					lastHitByRay.SendMessage ("OnRayHitEnded");	
				} catch (System.Exception ex) {
					Debug.Log (ex);
				}

			}
		}
	}
}
