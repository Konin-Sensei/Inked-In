using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyplat : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    // Update is called once per frame
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }
    void Update(){
        Vector3 desiredPos = new Vector3(transform.position.x + 1, transform.position.y, 0);
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime);
        transform.position = smoothedPos;
    }
}
