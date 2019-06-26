using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float speed;

    // Start is called before the first frame update
    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate(){
        Vector3 forward = new Vector3(1, 0, 0);
        rigidbody.MovePosition(transform.position + (forward * Time.deltaTime * speed));
    }
}
