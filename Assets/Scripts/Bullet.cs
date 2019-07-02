using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float duration;
    float Timer;

    void Start(){
        Timer = duration;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Barrier"){
            Destroy(gameObject);
        }
        if(other.tag == "Dots"){
            Destroy(gameObject);
        }
    }

    void Update(){
        Timer -= Time.deltaTime;
        transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, 0);
        if(Timer < 0){
            Destroy(gameObject);
        }
    }
}
