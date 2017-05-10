using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {
	public Canvas pauseMenu;
	public Button resumeText;
	public Button quitText;
	bool paused;
	List<AudioSource> inGameAudio = new List<AudioSource> ();

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		pauseMenu.enabled = false;
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		resumeText = resumeText.GetComponent<Button>();
		quitText = quitText.GetComponent<Button>();

		foreach (AudioSource go in GameObject.FindObjectsOfType(typeof(AudioSource))) {
			inGameAudio.Add (go);
		}

	}

	public void StartLevel(){
		gameUnPaused ();
	}

	public void ExitGame(){
		paused = false;
		SceneManager.LoadScene (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !paused) {
			gamePaused (); 
		} else if (Input.GetKeyDown (KeyCode.Escape) && paused) {
			gameUnPaused ();
		}
	}


	void gameUnPaused(){
		paused = false;
		pauseMenu.enabled = false;

		for (int i = 0; i < inGameAudio.Count; i++) {
			inGameAudio [i].UnPause ();
		}

		if (Time.timeScale == 0.0f) {            
			Time.timeScale = 1.0f; 
		}
	}

	void gamePaused(){
		pauseMenu.enabled = true;
		paused = true;

		if (Time.timeScale == 1.0f) {            
			Time.timeScale = 0.0f;
			for (int i = 0; i < inGameAudio.Count; i++) {
				inGameAudio [i].Pause ();
			}
		} else {
			Time.timeScale = 1.0f;
		}
	}
}
