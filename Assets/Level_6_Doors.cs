using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_6_Doors : MonoBehaviour
{
    public GameObject[] door1 = new GameObject[4];
    public GameObject door2;

    void Start(){
        for(int i = 0; i < 4; i++){
            door1[i].SetActive(true);
        }
        door2.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            for(int i = 0; i < 4; i++){
                door1[i].SetActive(false);
            }
            door2.SetActive(true);
        }
    }
}
