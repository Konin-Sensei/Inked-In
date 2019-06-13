using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour {

	public string nextLevel;

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F)) {
			SceneManager.LoadScene (nextLevel);
		}
	}		
}