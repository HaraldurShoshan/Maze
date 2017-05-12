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
	Vector3 SpawnPoint;
	public GameObject player;
	public GameObject platform;
	public GameObject cam;
	// Use this for initialization
	void Start () {
		LevelCounter = 0;
		SpawnPoint = new Vector3 (-5, -0.4f, 25);
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
		if (!platform.GetComponent<MovingPlatform>().alive) {
			
			StartCoroutine (Respawn ());
			platform.GetComponent<MovingPlatform> ().alive = true;

		}
		Debug.Log (LevelCounter);
	}

	IEnumerator Respawn()
	{
		cam.SetActive (true);
		yield return new WaitForSeconds (6);
		player.transform.position = SpawnPoint;
		cam.SetActive (false);
	}
}
