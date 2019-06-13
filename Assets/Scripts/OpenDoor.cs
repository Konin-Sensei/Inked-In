using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public SpriteRenderer[] doorSprite;

    void Start(){
        GetComponent<SpriteRenderer>().sprite = doorSprite[0].sprite;
    }

    void OnTriggerEnter2D(Collider2D other){
        GetComponent<SpriteRenderer>().sprite = doorSprite[1].sprite;
    }

    void OnTriggerExit2D(Collider2D other){
        GetComponent<SpriteRenderer>().sprite = doorSprite[0].sprite;
    }
}
