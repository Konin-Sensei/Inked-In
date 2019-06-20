using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            other.transform.position = new Vector3(173.9f, 19.83f, 0f);
        }
    }
}
