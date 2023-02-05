using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTrigger : MonoBehaviour
{
    public GameObject overworld_skybox_handler;
    public GameObject underworld_skybox_handler;
    void Start(){
        overworld_skybox_handler.SetActive(true);
        underworld_skybox_handler.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            overworld_skybox_handler.SetActive(false);
            underworld_skybox_handler.SetActive(true);
        }
    }
}
