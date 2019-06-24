using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingIce : MonoBehaviour
{
    PolygonCollider2D ice_collider;
    // Start is called before the first frame update
    void Start(){
        ice_collider = GetComponent<PolygonCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Destroy(other);
        }else if(other.tag == "Barrier" || other.tag == "Dots"){
            Destroy(gameObject);
        }
    }
}
