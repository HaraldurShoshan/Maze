using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button quitText;


	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		quitText = quitText.GetComponent<Button> ();
		quitMenu.enabled = false;
	}

	public void ExitPress(){
		quitMenu.enabled = true;
		startText.enabled = false;
		quitText.enabled = false;
		startText.gameObject.SetActive (false);
		quitText.gameObject.SetActive (false);
	}

	public void NoPress(){
		quitMenu.enabled = false;
		startText.enabled = true;
		quitText.enabled = true;
		startText.gameObject.SetActive (true);
		quitText.gameObject.SetActive (true);
	}

	public void StartLevel(){
		SceneManager.LoadScene (1);
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
