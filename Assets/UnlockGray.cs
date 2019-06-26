using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockGray : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            ColorProgress.level[7] = true;
        }
    }
}
