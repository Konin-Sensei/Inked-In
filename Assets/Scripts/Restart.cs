using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
	
	// Update is called once per frame

	string scene;

	void Start () {
		scene = SceneManager.GetActiveScene().name;


	}
	void Update () {

		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (scene);
		}
		
	}
}