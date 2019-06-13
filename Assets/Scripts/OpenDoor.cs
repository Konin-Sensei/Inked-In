using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public SpriteRenderer[] doorSprite;
	public string nextLevel;
	public bool alwaysOpen;

    void Start(){
        GetComponent<SpriteRenderer>().sprite = doorSprite[0].sprite;
    }

    void OnTriggerEnter2D(Collider2D other){
	if((PlayerPrefs.GetInt(nextLevel, 0) == 1) || alwaysOpen)//The door only opens a crack if you've beaten the level it came from or if we set it to always be open (levelSelect/startgame/quit/etc)
		{
			GetComponent<SpriteRenderer>().sprite = doorSprite[1].sprite;
		}
    }

    void OnTriggerExit2D(Collider2D other){
        GetComponent<SpriteRenderer>().sprite = doorSprite[0].sprite;
    }
}
