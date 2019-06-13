using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Reset : MonoBehaviour {

    public GameObject player;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            player.transform.position = new Vector3(450, 280, 0);
        }
    }
}