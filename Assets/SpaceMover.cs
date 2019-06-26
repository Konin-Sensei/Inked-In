using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMover : MonoBehaviour
{
    public float speed;
     Rigidbody2D rigidbody;
    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
        Vector2 constant_velocity = new Vector2(speed * Time.deltaTime, rigidbody.velocity.y);
        rigidbody.velocity = constant_velocity;
    }
}
