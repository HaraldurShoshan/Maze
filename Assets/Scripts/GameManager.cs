using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int LevelCounter;
	public GameObject lf_one;
	public GameObject lf_two;
	public GameObject lf_three;
	private bool lfFirst;
	private bool lfSecond;
	private bool lfThird;
	Vector3 SpawnPoint;
	public GameObject player;
	public GameObject platform;
	public Canvas deathCan;
	CanvasGroup deathAlpha;
	private bool oneTime;

	// Use this for initialization
	void Start () {
		LevelCounter = 0;
		SpawnPoint = new Vector3 (-5, 2f, 25);
		deathAlpha = deathCan.GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (lf_one.GetComponent<LeverFinished> ().Levelfinished && !lfFirst) {
			LevelCounter++;
			lfFirst = true;
			SpawnPoint = new Vector3 (-4.8f, -0.4f, -11.5f);
			Debug.Log ("First");
		
		}
		if (lf_two.GetComponent<LeverFinished> ().Levelfinished && !lfSecond) {
			LevelCounter++;
			lfSecond = true;
			SpawnPoint = new Vector3 (13.1f, -0.4f, -44.4f);
			Debug.Log ("Second");
		
		}
		if (lf_three.GetComponent<LeverFinished> ().Levelfinished && !lfThird) {
			LevelCounter++;
			lfThird = true;
			SpawnPoint = new Vector3 (-11.7f, -0.4f, -72.9f);
			Debug.Log ("Third");
		
		}
		if (platform.GetComponent<MovingPlatform>().fadeToBlack && !oneTime) {
			oneTime = true;
			StartCoroutine (Respawn ());
		}

		if (platform.GetComponent<MovingPlatform> ().fadeToBlack) {
			deathAlpha.alpha += (0.6f * Time.deltaTime);
		}


		Debug.Log (LevelCounter);
	}

	IEnumerator Respawn()
	{
		yield return new WaitForSeconds (9);
		player.transform.position = SpawnPoint;
		deathAlpha.alpha = 0.0f;
		platform.GetComponent<MovingPlatform> ().fadeToBlack = false;
		oneTime = false;
	}
}
