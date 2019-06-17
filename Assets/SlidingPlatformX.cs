using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlidingPlatformX : MonoBehaviour
{
    private Vector3 initial_position;
    private Rigidbody2D rigidbody_2d;
    public float horizontal_range;
    public float vertical_range;

    void Start(){
        initial_position = transform.position;
        rigidbody_2d = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
        Vector3 newPosition = new Vector3(horizontal_range*Mathf.Cos(Time.time), vertical_range*Mathf.Cos(Time.time), 0);
        rigidbody_2d.MovePosition(initial_position + newPosition);
    }
}
