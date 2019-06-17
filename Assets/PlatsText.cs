using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatsText : MonoBehaviour
{
    public IntroductionText intro_text;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player")
            intro_text.setText("Some platforms move so be\nsure to time your jumps!\n");
    }
}
