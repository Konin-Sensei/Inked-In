using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurprisePlatform : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            GetComponent<Rigidbody2D>().gravityScale = 20.0f;
        }
        if(other.tag == "Barrier"){
            Destroy(gameObject);
        }
    }
}
