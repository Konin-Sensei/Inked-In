using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitDoor : MonoBehaviour {

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F)) {
			Application.Quit();
		}
	}		
}