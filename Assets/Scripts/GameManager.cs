using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public int LevelCounter;
	public GameObject lf_one;
	public GameObject lf_two;
	public GameObject lf_three;
	private bool lfFirst;
	private bool lfSecond;
	private bool lfThird;
	// Use this for initialization
	void Start () {
		LevelCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (lf_one.GetComponent<LeverFinished> ().Levelfinished && !lfFirst) {
			LevelCounter++;
			lfFirst = true;
		}
		if (lf_two.GetComponent<LeverFinished> ().Levelfinished && !lfSecond) {
			LevelCounter++;
			lfSecond = true;
		}
		if (lf_three.GetComponent<LeverFinished> ().Levelfinished && !lfThird) {
			LevelCounter++;
			lfThird = true;
		}


		Debug.Log (LevelCounter);
	}
}
