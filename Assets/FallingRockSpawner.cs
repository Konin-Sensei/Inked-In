using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockSpawner : MonoBehaviour
{
    public GameObject falling_rock;
    public float spawn_rate;
    float Timer;

    void Start(){
        Timer = spawn_rate;
    }

    void Update(){
        Timer -= Time.deltaTime;
        if(Timer < 0){
            GameObject rock_clone = Instantiate(falling_rock, transform.position, transform.rotation) as GameObject;
            Timer = spawn_rate;
        }
    }
}
