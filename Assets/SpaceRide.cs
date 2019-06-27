using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRide : MonoBehaviour
{
    public float speed;
    public float altitude_rate;
    Rigidbody2D rigidbody;
    public float level_duration;
    float Timer;
    public GameObject portal;
    public GameObject audio_source;
    public GameObject gray_unlocker;
    bool gray_unlocked;
    bool doorGenerated;
    public float altitude;
    float sign;

    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
        Timer = level_duration;
        gray_unlocked = false;
        doorGenerated = false;
    }

    void FixedUpdate(){
        if(transform.position.y > altitude){
            sign = -1;
        }else{
            sign = 1;
        }
        Vector3 forward = new Vector3(1, sign * altitude_rate * (transform.position.y - altitude), 0);
        rigidbody.MovePosition(transform.position + (forward * Time.deltaTime * speed));
        Debug.DrawRay(transform.position, forward, Color.red, 1f, true);
        Timer -= Time.deltaTime;
        if(Timer < 30 && !gray_unlocked){
            unlockgray();
            gray_unlocked = true;
        }
        if(Timer < 0 && !doorGenerated){
            doorGenerated = true;
            endLevel();
        }
    }

    void endLevel(){
        Vector3 portal_position = new Vector3(transform.position.x + 32f, transform.position.y, 0); 
        GameObject portal_copy = Instantiate(portal, portal_position, transform.rotation) as GameObject;
        portal_copy.GetComponent<Space_Door>().audio_source = audio_source;
    }

    void unlockgray(){
        Vector3 gray_position = new Vector3(transform.position.x + 32f, transform.position.y, 0);
        GameObject gray_unlocker_copy = Instantiate(gray_unlocker, gray_position, transform.rotation) as GameObject;
    }
}
