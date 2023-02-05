using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject button_unpressed;
    public GameObject button_pressed;
    public GameObject acid_ferry;
    public GameObject elevator;
    public GameObject elevator_sign;
    public GameObject ferry_sign1;
    public GameObject ferry_sign2;


    void Start(){
        button_pressed.SetActive(false);
        button_unpressed.SetActive(true);
        acid_ferry.SetActive(false);
        elevator.SetActive(false);
        elevator_sign.SetActive(false);
        ferry_sign1.SetActive(false);
        ferry_sign2.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            button_pressed.SetActive(true);
            button_unpressed.SetActive(false);
            acid_ferry.SetActive(true);
            elevator.SetActive(true);
            elevator_sign.SetActive(true);
            elevator_sign.transform.Rotate(Vector3.forward * -200);
            ferry_sign1.SetActive(true);
            ferry_sign2.SetActive(true);
        }
    }
}
