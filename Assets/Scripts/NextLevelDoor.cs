using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour {

	public string nextLevel;
	public bool levelSelectDoor; //this must be set so we can make sure you can't just enter any level in levelSelect menu
	private SaveDoor screwKonin = new SaveDoor();

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F) && !levelSelectDoor) {
			screwKonin.trySave(nextLevel); //we need to make sure the var nextLevel in this is the same as the keys in SaveDoor for this to work...
			SceneManager.LoadScene (nextLevel);
		}
		if(other.tag == "Player" && Input.GetKeyDown(KeyCode.F) && levelSelectDoor) {
			if(PlayerPrefs.GetInt(nextLevel, 0) == 1)
			{
				SceneManager.LoadScene(nextLevel); //if this is on the level select screen, you can only travel if you've beaten the previous level.
			}
		}
	}		
}