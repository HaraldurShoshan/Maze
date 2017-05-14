using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCollider : MonoBehaviour {
	public bool isFinished;
	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Player")){
			isFinished = true;
		}
	}
}
