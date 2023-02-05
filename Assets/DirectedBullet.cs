using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedBullet : MonoBehaviour
{
    public Transform target;
    public float speed;
    private Vector3 target_position;
    private Vector3 direction;
    public float duration;
    void Start(){
        target_position = target.position;
        direction = (target.position - transform.position).normalized;
    }

    void Update(){
        duration -= Time.deltaTime;
        transform.position += direction * Time.deltaTime * speed;
        if(duration <= 0){
            Destroy(gameObject);
        }
    }
}
