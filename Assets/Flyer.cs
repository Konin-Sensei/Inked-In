using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : MonoBehaviour
{
    Animator flyer_animator;
    Rigidbody2D flyer_body;
    bool isFlipped;

    void Start(){
        flyer_animator = GetComponent<Animator>();
        flyer_body = GetComponent<Rigidbody2D>();
    }

    void Update(){
        flyer_animator.SetFloat("Velocity",flyer_body.velocity.x);
        if(flyer_body.velocity.x > 0 && isFlipped){
            isFlipped = false;
            flyer_animator.SetBool("Mirror", isFlipped);
        }else if(flyer_body.velocity.x < 0 && !isFlipped){
            isFlipped = true;
            flyer_animator.SetBool("Mirror", isFlipped);
        }
    }
}
