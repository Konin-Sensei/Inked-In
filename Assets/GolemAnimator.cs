using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAnimator : MonoBehaviour
{
    public SpriteRenderer[] golem_renderers = new SpriteRenderer[10];
    private Rigidbody2D golem_body;
    private bool isFlipped;

    void Start(){
        isFlipped = false;
        golem_body = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update(){
        if(golem_body.velocity.x > 0 && isFlipped){
            isFlipped = false;
        }else if(golem_body.velocity.x < 0 && !isFlipped){
            isFlipped = true;
        }
        for(int i = 0; i < 10; i++){
            golem_renderers[i].flipX = isFlipped;
        }
    }
}
