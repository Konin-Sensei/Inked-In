using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float forward_offset;
    public float altitude_min;
    public float altitude_max;
    public float forward_min;
    public float forward_max;
    public float spawn_time_min;
    public float spawn_time_max;
    float Timer;
    public float rotation_max;

    void Start(){
        Timer = 2;        
    }

    void FixedUpdate(){
        Timer -= Time.deltaTime;
        if(Timer <= 0){
            Vector3 newPosition = new Vector3(transform.position.x + forward_offset + Random.Range(forward_min, forward_max), transform.position.y + Random.Range(altitude_min, altitude_max), 0);
            GameObject obstacle_clone = Instantiate(obstacle, newPosition, Quaternion.Euler(0f, 0f, Random.Range(0f,rotation_max)));
            Timer = Random.Range(spawn_time_min, spawn_time_max);
            obstacle_clone.GetComponent<PlayerDeath>().level_name = "Level 7";
            obstacle_clone.GetComponent<PlayerDeath>().level_index = 7;
        }
    }
}
