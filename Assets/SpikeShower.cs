using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShower : MonoBehaviour
{
    public GameObject ice_spike;
    public float speed_modifier;
    private float Timer;

    void Start(){
        Timer = 1f;
    }

    // Update is called once per frame
    void Update(){
        Timer -= Time.deltaTime * speed_modifier;
        if(Timer <= 0){
            drop_ice();
            Timer = Random.Range(1.0f, 5.0f);
        }
    }

    void drop_ice(){
        GameObject ice_spike_clone = Instantiate(ice_spike, new Vector3(transform.position.x + Random.Range(-3.0f, 3.0f), transform.position.y, 0), transform.rotation) as GameObject;
    }
}
