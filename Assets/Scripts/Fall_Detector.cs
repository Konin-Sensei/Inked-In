using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall_Detector : MonoBehaviour {
	
	string scene;

	void Start () {
		scene = SceneManager.GetActiveScene().name;
	}
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            SceneManager.LoadScene (scene);
        }
    }
}