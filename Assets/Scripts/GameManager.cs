using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	public GameObject lf_one;
	public GameObject lf_two;
	public GameObject lf_three;
	public GameObject player;
	public GameObject platform;


	private bool lfFirst;
	private bool lfSecond;
	private bool lfThird;
	private bool oneTime;

	public int LevelCounter;

	public Canvas deathCan;
	CanvasGroup deathAlpha;
	Vector3 SpawnPoint;

	public GameObject DoorFirstRoom;
	public GameObject DoorFirstBetween;
	public GameObject DoorSecondBetween;
	public GameObject DoorThirdBetween;

	public GameObject leverInFirstDoor;
	public GameObject leverRoomBetween1;
	public GameObject leverRoomBetween2;
	public GameObject leverRoomBetween3;

	public GameObject exitCollider;
	public GameObject exitDoorBehind;
	AudioSource doorAudio;

	public Camera fpsCam;

	// Use this for initialization
	void Start () {
		//		DontDestroyOnLoad(gameObject);
		LevelCounter = 0;
		//		SpawnPoint = new Vector3 (-5, 2f, 25);
		SpawnPoint = new Vector3 (13.1f, -0.4f, -44.4f);

		deathAlpha = deathCan.GetComponent<CanvasGroup> ();
	}

	// Update is called once per frame
	void Update () {

		if (lf_one.GetComponent<LeverFinished> ().Levelfinished && !lfFirst) {
			LevelCounter++;
			lfFirst = true;
			SpawnPoint = new Vector3 (-4.8f, -0.4f, -11.5f);
			leverRoomBetween1.GetComponent<LeverNewMaze> ().canUse = true;
			Debug.Log ("First");

		}
		if (lf_two.GetComponent<LeverFinished> ().Levelfinished && !lfSecond) {
			LevelCounter++;
			lfSecond = true;
			SpawnPoint = new Vector3 (13.1f, -0.4f, -44.4f);
			leverRoomBetween2.GetComponent<LeverNewMaze> ().canUse = true;
			Debug.Log ("Second");

		}
		if (lf_three.GetComponent<LeverFinished> ().Levelfinished && !lfThird) {
			LevelCounter++;
			lfThird = true;
			SpawnPoint = new Vector3 (-11.7f, -0.4f, -72.9f);
			leverRoomBetween3.GetComponent<LeverNewMaze> ().canUse = true;
			Debug.Log ("Third");

		}
		if (platform.GetComponent<MovingPlatform>().fadeToBlack && !oneTime) {
			oneTime = true;
			StartCoroutine (Respawn ());
		}

		if (platform.GetComponent<MovingPlatform> ().fadeToBlack) {
			deathAlpha.alpha += (0.6f * Time.deltaTime);
		}

		if (exitCollider.GetComponent<ExitCollider> ().isFinished) {
			platform.GetComponent<MovingPlatform> ().rising = false;
			fpsCam.GetComponent<AudioSource> ().volume -= (0.004f * Time.deltaTime); 
			exitDoorBehind.GetComponent<Animator> ().SetBool ("isOpen", true);
			exitDoorBehind.GetComponent<AudioSource> ().Play ();
			exitDoorBehind.GetComponent<LastDoor> ().finish = true;
		}



		Debug.Log (LevelCounter);
	}

	IEnumerator Respawn()
	{
		DoorFirstRoom.GetComponent<Animator> ().SetBool ("isOpen", false);
		leverInFirstDoor.GetComponent<Animator> ().SetBool ("isOpen", false);
		leverInFirstDoor.GetComponent<LeverInFirstRoom> ().isOpen = false;

		DoorFirstBetween.GetComponent<Animator> ().SetBool ("isOpen", false);
		leverRoomBetween1.GetComponent<Animator> ().SetBool ("isOpen", false);
		leverRoomBetween1.GetComponent<LeverNewMaze> ().isOpen = false;

		DoorSecondBetween.GetComponent<Animator> ().SetBool ("isOpen", false);
		leverRoomBetween2.GetComponent<Animator> ().SetBool ("isOpen", false);
		leverRoomBetween2.GetComponent<LeverNewMaze> ().isOpen = false;

		DoorThirdBetween.GetComponent<Animator> ().SetBool ("isOpen", false);
		leverRoomBetween3.GetComponent<Animator> ().SetBool ("isOpen", false);
		leverRoomBetween3.GetComponent<LeverNewMaze> ().isOpen = false;

		yield return new WaitForSeconds (9);
		player.transform.position = SpawnPoint;
		deathAlpha.alpha = 0.0f;
		platform.GetComponent<MovingPlatform> ().fadeToBlack = false;
		oneTime = false;
		//		SceneManager.LoadScene (1);
	}


}
