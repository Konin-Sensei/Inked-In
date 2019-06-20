using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingScript : MonoBehaviour
{

    public float bounciness;
    Rigidbody2D myBody;
    void OnCollisionEnter2D (Collision2D other)
    {
        print("Method entered");
        myBody = other.rigidbody;
        myBody.AddForce(new Vector2(other.relativeVelocity.x, other.relativeVelocity.y+4)*bounciness, ForceMode2D.Impulse);

    }

}
