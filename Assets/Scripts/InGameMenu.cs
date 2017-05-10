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

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		pauseMenu.enabled = false;
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		resumeText = resumeText.GetComponent<Button>();
		quitText = quitText.GetComponent<Button>();

	}

	public void StartLevel(){
		paused = false;
		pauseMenu.enabled = false;
	}

	public void ExitGame(){
		paused = false;
		SceneManager.LoadScene (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !paused) {
			pauseMenu.enabled = true;
			paused = true;
		} else if (Input.GetKeyDown (KeyCode.Escape) && paused) {
			pauseMenu.enabled = false;
			paused = false;
		}
	}
}
