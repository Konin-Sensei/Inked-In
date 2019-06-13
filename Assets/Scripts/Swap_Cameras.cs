using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap_Cameras : MonoBehaviour
{
    public Camera follow_cam;
    public Camera gap_cam;
    public float x, y, z;
    public GameObject wallpaper;

    void Start(){
        follow_cam.gameObject.SetActive(true);
        follow_cam.gameObject.tag = "MainCamera";
        gap_cam.gameObject.SetActive(false);
        gap_cam.gameObject.tag = "Inactive Camera";
    }

    public void enable_follow_camera(){
        gap_cam.gameObject.SetActive(false);
        gap_cam.gameObject.tag = "Inactive Camera";
        follow_cam.gameObject.SetActive(true);
        follow_cam.gameObject.tag = "MainCamera";
        wallpaper.transform.position = new Vector3(x, y, z);
    }

    public void enable_gap_camera(){
        follow_cam.gameObject.SetActive(false);
        follow_cam.gameObject.tag = "Inactive Camera";
        gap_cam.gameObject.SetActive(true);
        gap_cam.gameObject.tag = "MainCamera";
    }
}
