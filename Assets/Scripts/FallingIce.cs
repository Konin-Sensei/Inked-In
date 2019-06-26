using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingIce : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Barrier" || other.tag == "Dots"){
            Destroy(gameObject);
        }
    }
}
