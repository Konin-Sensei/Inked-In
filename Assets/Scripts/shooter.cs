using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public float Timer;
    public GameObject bullets;
    GameObject bullet_clone;
    float Timer_init;

    void Start(){
        Timer_init = Timer;
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0f){
            bullet_clone = Instantiate(bullets, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation) as GameObject;
            bullet_clone.tag = "Bullet";
            Timer = Timer_init;
        }
        
    }
}
