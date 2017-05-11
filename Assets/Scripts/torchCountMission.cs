using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchCountMission : MonoBehaviour {

	List<GameObject> goList = new List<GameObject> ();
	List<TorchesInFirstRoom> goObj = new List<TorchesInFirstRoom> ();
	bool[] boolArray = new bool[]{ false, false, false, false, false };
	public int counter;
	public bool missionAccomplished;

	// Use this for initialization
	void Start () {		
		foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))){
			if (go.name == "FireTorchFirstRoom") {
				TorchesInFirstRoom ts;
				ts = go.GetComponent<TorchesInFirstRoom>();
				goObj.Add (ts);

			}
		}
	}

	// Update is called once per frame
	void Update () {

		for(int i = 0; i < 5; i++){
			if (goObj [i].fireIsOn) {
				boolArray [i] = true;
			} 
		}

		if (checkForFalse()) {
			Debug.Log ("Mission accomplished");
			missionAccomplished = true;
		}
	}

	bool checkForFalse(){
		for (int i = 0; i < 5; i++) {
			if (!boolArray [i]) {
				return false;
			}
		}

		return true;
	}
}
