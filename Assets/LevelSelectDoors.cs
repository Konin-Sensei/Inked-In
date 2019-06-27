using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectDoors : MonoBehaviour {

	public string nextLevel;
	public int progressNeeded;
    public GameObject audio_source;

	void OnTriggerStay2D (Collider2D other){
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F) && ColorProgress.getLevel() >= progressNeeded){
            Destroy(audio_source);
			SceneManager.LoadScene (nextLevel);
		}
	}		
}