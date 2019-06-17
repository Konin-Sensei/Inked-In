using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawText : MonoBehaviour
{
    public IntroductionText intro_text;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player")
            intro_text.setText("Oh no!\nThis gap is too large to jump.\nClick and drag with the mouse\n            to draw a path!");
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player")
            intro_text.setText("That's all the instruction for now!\nJust ahead you'll find a door.\nPress the 'F' key when the door\n           opens to go through it!");
    }
}
