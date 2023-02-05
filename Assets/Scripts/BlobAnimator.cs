using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobAnimator : MonoBehaviour
{
    public Sprite[] states = new Sprite[3];
    private SpriteRenderer sprite_renderer;
    private Rigidbody2D rigidbody;
    private bool isFlipped;
    private Animator blob_animator;

    void Start(){
        sprite_renderer = GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = states[0];
        rigidbody = GetComponent<Rigidbody2D>();
        blob_animator = GetComponent<Animator>();
    }

    void Update(){
        blob_animator.SetFloat("Velocity",rigidbody.velocity.x);
        if(rigidbody.velocity.x > 0 && isFlipped){
            isFlipped = false;
        }else if(rigidbody.velocity.x < 0 && !isFlipped){
            isFlipped = true;
        }
        sprite_renderer.flipX = !isFlipped;
        blob_animator.SetBool("Mirror",isFlipped);
    }
}
