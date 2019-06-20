using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BubbleFollow : MonoBehaviour
{
    public Transform player;
    public GameObject temp;
    public float smoothCamera = 0.125f;
    public float x_offset;
    public float y_offset;
    SpriteRenderer sprite_renderer;

    void Start(){
        sprite_renderer = temp.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate(){
        if(!Input.GetKey (KeyCode.Mouse0)){
            if(sprite_renderer.flipX == true && x_offset < 0){
                x_offset *= -1;
            }else if(sprite_renderer.flipX == false && x_offset > 0){
                x_offset *= -1;
            }
            Vector3 offset = (new Vector3(x_offset, Mathf.Cos(Time.time) + y_offset, 0)); 
            Vector3 desiredPosition = player.position + offset;
            smoothCamera = 3*Math.Abs(Vector3.Distance(player.position, desiredPosition));
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothCamera * Time.deltaTime);
            transform.position = smoothedPosition;
        }else{
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 desiredPos = mousePos - (new Vector3(0, 0, -10));
            transform.position = desiredPos;
        }
    }
}
