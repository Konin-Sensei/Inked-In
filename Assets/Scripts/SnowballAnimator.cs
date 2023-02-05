using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballAnimator : MonoBehaviour
{
    public Transform player;
    private float Timer;
    public float speed;
    public float detectionRadius;

    // Update is called once per frame
    void Update(){
        if(Mathf.Abs(Vector3.Distance(transform.position, player.position)) < detectionRadius){
            ChasePlayer();
        }
        
    }

    void ChasePlayer(){
        Vector3 desiredPos = Vector3.Lerp(transform.position, player.position, speed *Time.deltaTime);
        transform.position = desiredPos;
    }
}
