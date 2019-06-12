using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	//stuff that's implemented
	private Transform target;
	public Vector2 push;
	public Rigidbody2D rb;
	public BoxCollider2D largeCollider;
	
	//stuff that's not implemented yet.
	public Transform currentGround;
	public RaycastHit2D[] raycastResults; //what the raycast "saw"
	public ContactFilter2D contactFilter; //filters results?
	
    // Start is called before the first frame update
    void Awake()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
		largeCollider = gameObject.GetComponent<BoxCollider2D>();
			//NEXT STEPS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			//set up a raycast pointing down that should return the platform in raycastResults
			//and use that reference in order to set boundaries on where the enemy can walk.
			//Long term goal: 
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
			push = new Vector2(10f, 0f);
		}
		else if(movex < 0f)
		{
			push = new Vector2(-10f, 0f);
		}
		
		rb.AddForce(push);
		//rb.velocity = new Vector2(movex * 10f, rb.velocity.y);

	}
}
