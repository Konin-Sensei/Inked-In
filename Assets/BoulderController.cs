using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float speed;

    // Start is called before the first frame update
    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        rigidbody.velocity = new Vector2(Time.deltaTime * speed, rigidbody.velocity.y);
    }
}
