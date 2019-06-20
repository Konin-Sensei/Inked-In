using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject button_unpressed;
    public GameObject button_pressed;
    public GameObject acid_ferry;
    public GameObject elevator;

    void Start(){
        button_pressed.SetActive(false);
        button_unpressed.SetActive(true);
        acid_ferry.SetActive(false);
        elevator.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            button_pressed.SetActive(true);
            button_unpressed.SetActive(false);
            acid_ferry.SetActive(true);
            elevator.SetActive(true);
        }
    }
}
