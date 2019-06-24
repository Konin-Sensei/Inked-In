using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScriptGeneral : MonoBehaviour
{
    public GameObject button_unpressed;
    public GameObject button_pressed;
    public int level;


    void Start(){
        button_pressed.SetActive(false);
        button_unpressed.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            button_pressed.SetActive(true);
            button_unpressed.SetActive(false);
            ColorProgress.level[level] = true;
        }
    }
}
