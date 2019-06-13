using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu2 : MonoBehaviour {

	public bool isPaused;
	public string mainMenu;
	public GameObject pauseMenuUI;

	public GameObject eventSystem;
	
	// Update is called once per frame
	void Update () {

		if (isPaused) {

			pauseMenuUI.SetActive (true);
			Time.timeScale = 0f;
			//eventSystem.SetActive(false);

		} else {
			pauseMenuUI.SetActive (false);
			Time.timeScale = 1f;
			//eventSystem.SetActive(true);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {

			isPaused = !isPaused;
		}
		
	}

	public void Resume ()
	{
		isPaused = false;
	}

	public void Quit () 
	{
		SceneManager.LoadScene (mainMenu);
		isPaused = false;
	}
}