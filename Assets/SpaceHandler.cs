using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceHandler : MonoBehaviour
{
    public GameObject original_player;
    public GameObject space_player;
    public GameObject pseudo_platform;
    public GameObject start_camera;
    public GameObject space_camera;

    void Start(){
        original_player.SetActive(true);
        space_player.SetActive(false);
        pseudo_platform.SetActive(true);
        start_camera.SetActive(true);
        space_camera.SetActive(false);
        start_camera.tag = "MainCamera";
        space_camera.tag = "Untagged";
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            original_player.SetActive(false);
            space_player.SetActive(true);
            pseudo_platform.SetActive(false);
            start_camera.SetActive(false);
            space_camera.SetActive(true);
            start_camera.tag = "Untagged";
            space_camera.tag = "MainCamera";
        }
    }
}
