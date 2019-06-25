using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            other.transform.position = new Vector3(173.9f, 19.83f, 0f);
        }
    }

    void Update(){
        transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, 0);
    }
}
