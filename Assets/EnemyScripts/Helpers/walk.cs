using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : Helper, Ihelper
{

	private RaycastHit2D hitDown;
	private RaycastHit2D hit;
	private int speed;
	private Rigidbody2D body;
	private GameObject form = new GameObject();
	private bool movingRight = true;//we may be able to use cos/sin to avoid this entirely
	//but not if we want them to find their own path... It would speed up the setBounds class.
	public float raycast_length;

	public void set_raycast_length(float length_in){
		raycast_length = length_in;

	}

	public void setSpeed(int input)
	{
		speed = input;
	}
	
	public walk(string input)
	{
		job = input;
	}
	
	public void setBody(Rigidbody2D input)
	{
		body = input;
	}
	
	public override void handle(string request)
	{
		if(request.Contains(job))
		{
			getMoving();
		}
		else if(request.Contains("turn"))
		{
			movingRight = !movingRight;
			getMoving();
		}
		else
		{
			if(comrade != null)
			{
				comrade.handle(request);
			}
			else
			{
			Debug.Log("walk.handle(string) '" + request + "' helper not found.");
			}
		}
		
	}
	private void checkEdges() //will see if we're too close to the edge and turn us around if we are (change the value of movingRight).
	{
		LayerMask mask = LayerMask.GetMask("Ground");
		Vector2 downRight = new Vector2(1, -1);
		Vector2 downLeft = new Vector2(-1, -1);
		if(movingRight)
		{
			hit = Physics2D.Raycast(body.position, downRight, raycast_length, mask);//2.0f might be too far, but we'll see. Might change during testing.
		}
		else
		{
			hit = Physics2D.Raycast(body.position, downLeft, raycast_length, mask);	
		}
		
		
		if(hit.collider == null)
		{
			movingRight = !movingRight;//flip the value of bool
		}
		else
		{
			//continue moving in same direction.
		}
		
	}
	

	
	private void getMoving()
	{
		LayerMask mask = LayerMask.GetMask("Ground");
		hitDown = Physics2D.Raycast(body.position, new Vector2(0, -1), 1, mask);
		if(hitDown.collider == null)
		{
			body.velocity = new Vector2(0, -20);
		}
		else
		{
		checkEdges();
		if(movingRight)
		{
			goRight();
		}
		else
		{
		goLeft();
		}
		}
	}
	
	private void goRight()
	{
		body.velocity = form.transform.right  * speed;
	}
	
	private void goLeft()
	{
		body.velocity = form.transform.right * -1 * speed;

	}
	
	
}
