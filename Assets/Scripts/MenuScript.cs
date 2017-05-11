using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Button startText;
	public Button quitText;

	// Use this for initialization
	void Start () {
		if (Time.timeScale == 0.0f) {            
			Time.timeScale = 1.0f; 
		}
		Cursor.visible = false;
		startText = startText.GetComponent<Button> ();
		quitText = quitText.GetComponent<Button> ();
	}

//	public void ExitPress(){
//		startText.enabled = false;
//		quitText.enabled = false;
//		startText.gameObject.SetActive (false);
//		quitText.gameObject.SetActive (false);
//	}

//	public void NoPress(){
//		startText.enabled = true;
//		quitText.enabled = true;
//		startText.gameObject.SetActive (true);
//		quitText.gameObject.SetActive (true);
//	}

	public void StartLevel(){
		SceneManager.LoadScene (1);
	}

	public void ExitGame(){
		Debug.Log ("Quitting");
		Application.Quit ();
	}
}
