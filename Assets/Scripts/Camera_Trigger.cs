using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Trigger : MonoBehaviour
{
    public Swap_Cameras swap_script;

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player"){
            swap_script.enable_gap_camera();
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.tag=="Player"){
            swap_script.enable_follow_camera();
        }
    }
}
