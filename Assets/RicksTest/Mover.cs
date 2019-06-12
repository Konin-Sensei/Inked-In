using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	private Transform target;
	public Vector2 push;
	public Rigidbody2D rb;
	public BoxCollider2D bc;
	
    // Start is called before the first frame update
    void Awake()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
		bc = gameObject.GetComponent<BoxCollider2D>();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
		lookAbout();
        
    }
	
	void lookAbout()
	{
		int lookx = 0;
		//int yDir = 0;//to be used later; focusing on the x for now.
		if(target.position.x > transform.position.x) {lookx = 1;} 
		else if(transform.position.x > target.position.x) {lookx = -1;}
		attemptMove(lookx);
		
	}
	
	void attemptMove(float amovex)
	{
		//move could output bool in the future telling this whether or not we succeeded. for now just try to move in that dirX
		move(amovex);
		
		//should check to see if we have hit something after the move func.
	}
	
	void move(float movex)
	{
		Vector2 push = new Vector2(0, 0);
		if(movex > 0f)
		{
			push = new Vector2(100f, 0f);
		}
		else if(movex < 0f)
		{
			push = new Vector2(-100f, 0f);
		}
		
		rb.AddForce(push);
		//rb.velocity = new Vector2(movex * 10f, rb.velocity.y);

	}
}
