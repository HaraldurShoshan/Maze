using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTorch : MonoBehaviour {

	public bool fireDies;

	// Use this for initialization
	void Start () {
		fireDies = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (fireDies) 
		{
			gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag ("Water")) 
		{			
			fireDies = true;
		} 
		else 
		{
			fireDies = false;
		}
	}
}
