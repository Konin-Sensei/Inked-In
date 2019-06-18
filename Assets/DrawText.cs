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
            intro_text.setText("Notice that your ink remaining has\ndropped! You have a limited\namount per level!");
    }
}
