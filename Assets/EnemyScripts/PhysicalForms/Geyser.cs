using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    public float duration;
    public float height;
    public float interval;
    public float speed;
    float Timer;
    Vector3 restPosition;
    bool isUp;
    bool hasOscillated;
    float oscillation_length;
    void Start(){
        Timer = interval;
        restPosition = transform.position;
        isUp = false;
        oscillation_length = duration;
        hasOscillated = false;
    }

    void FixedUpdate(){
        if(Timer <= 0){
            activate_geyser();
        }
        else if(isUp){
            oscillate();
        }
        else if(hasOscillated){
            deactivate_geyser();
        }else{
            Timer -= Time.deltaTime;
        }
    }

    void activate_geyser(){
        Vector3 desiredPosition = new Vector3(restPosition.x, restPosition.y + height, 0);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        transform.position = smoothedPosition;
        if(Vector3.Distance(transform.position, desiredPosition) < 0.4){
            Timer = interval;
            isUp = true;
        }
    }

    void oscillate(){
        if(oscillation_length > 0){
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * Mathf.Cos(Time.time), 0);
            transform.position = desiredPosition;
            oscillation_length -= Time.deltaTime;
        }else{
            isUp = false;
            hasOscillated = true;
            oscillation_length = duration;
        }
    }

    void deactivate_geyser(){
        Vector3 desiredPosition = new Vector3(restPosition.x, restPosition.y, 0);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        transform.position = smoothedPosition;
        if(Vector3.Distance(transform.position, desiredPosition) < 0.4){
            hasOscillated = false;
        }
    }
}
