using UnityEngine.SceneManagement;
using UnityEngine;
//lotta comments to help you cuz I know you're gonna have to read this (whoever you are)
//but it's pretty straightforward. Look up the doc for PlayerPrefs to get a simple overview.
//specifically GetInt needs some explanation.
public class SaveDoor : MonoBehaviour
{
	public void initSaves()//to be called when you open the game.
	{
		if(PlayerPrefs.GetInt("gamePlayed", 0) == 0)
		{
			PlayerPrefs.SetInt("tutorial", 1); //setting all doors to 0 except tut, when you first start game.
			PlayerPrefs.SetInt("level one", 0);
			PlayerPrefs.SetInt("gamePlayed", 1);
		}
	}
	
	//named trySave because it'll check if it's already saved and do nothing if true, save if false. (to simplify the code for replays
	//levelName is just a key that this function needs to know so it'll only mess with that part of the save file.
	  public void trySave(string levelName) 
	  {
		  if(PlayerPrefs.GetInt(levelName, 0) == 0)
		  {
			PlayerPrefs.SetInt(levelName, 1);
		  }
	  }// I think that's it... Just put the trySave fun in the doors
	  //make sure the door script is set on levelselect so that the proper doors are invisible if the level isn't done
  //make sure the initSaves is set up in the main menu on start() and that it gets updated to make way for new doors as we
  //add more levels. annnd make sure the keys stay the same in wording and capitals throughout those three areas.
 }
