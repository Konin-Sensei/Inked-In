using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Space_Door : MonoBehaviour {

	public string nextLevel;
	public GameObject audio_source;

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player"){
			Destroy(audio_source);
			SceneManager.LoadScene (nextLevel);
		}
	}		
}