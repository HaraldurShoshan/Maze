using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroFade : MonoBehaviour {

	public Canvas fade;
	CanvasGroup fadeAlpha;
	private bool hit;
	private bool load;

	// Use this for initialization
	void Start () {
		Debug.Log ("test");	
		fadeAlpha = fade.GetComponent<CanvasGroup> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Torch")) {
			hit = true;
		}
		if (other.CompareTag ("Spawn")) {
			load = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (hit) {
			fadeAlpha.alpha += (0.6f * Time.deltaTime);
		}
		if (load) {
			SceneManager.LoadScene (2);
		}
	}



}
