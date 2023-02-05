using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerAnimator : MonoBehaviour
{
    public Transform player;
    bool isFlipped;
    SpriteRenderer sprite_renderer;

    void Start(){
        sprite_renderer = GetComponent<SpriteRenderer>();
    }

    void Update(){
        if(transform.position.x < player.position.x){
            isFlipped = true;
            sprite_renderer.flipX = isFlipped;
        }else if(transform.position.x > player.position.x){
            isFlipped = false;
            sprite_renderer.flipX = isFlipped;
        }
    }
}
