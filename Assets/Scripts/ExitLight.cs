using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLight : MonoBehaviour {
	public bool hit;
	public bool unHit;
	Light light;
	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Player")){
			hit = true;
			unHit = false;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.CompareTag ("Player")) {
			unHit = true;
			hit = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (hit) {
			if (light.intensity < 30) {
				light.intensity += (5f * Time.deltaTime);
			}
		}
		if (unHit) {
			if (light.intensity > 0f) {
				light.intensity -= (10f * Time.deltaTime);
			}
		}
	}
}
