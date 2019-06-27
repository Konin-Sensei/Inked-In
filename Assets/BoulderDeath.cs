using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderDeath : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Barrier"){
            Destroy(gameObject);
        }
    }
}
