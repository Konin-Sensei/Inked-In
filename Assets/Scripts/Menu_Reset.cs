using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Reset : MonoBehaviour {

    public GameObject player;
    public float x;
    public float y;
    public float z;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            player.transform.position = new Vector3(x, y, z);
        }
    }
}