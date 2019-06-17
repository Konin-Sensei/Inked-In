using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpText : MonoBehaviour
{
    public IntroductionText intro_text;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player")
            intro_text.setText("Try using the space key to jump!\n");
    }
}
