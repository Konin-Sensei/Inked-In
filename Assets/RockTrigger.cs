using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrigger : MonoBehaviour
{
    public GameObject rock;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            GameObject rock_clone = Instantiate(rock, transform.position, transform.rotation) as GameObject;
        }
    }
}
