using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToward : Helper, Ihelper
{
	private int speed;
	private Rigidbody2D body;
	private RaycastHit2D hit;
	
	
		public void setSpeed(int input)
	{
		speed = input;
	}
	
	
	public void setBody(Rigidbody2D input)
	{
		body = input;
	}
	

	
    public override void handle(string request)
	{
		
		callLeader(request);//this is to let the check4edges class know which direction we're moving.

		if(request.Contains("Right") || request.Contains("Left"))//contains the word Right or Left
		{
			getMoving(request);
		}
		else
		{
			if(comrade != null)
			{
				comrade.handle(request);
			}
			else
			{
			Debug.Log("RunToward.handle(string) '" + request + "' helper not found.");
			}
		}
		
	}
	
	public bool tooClose()
	{
		Vector2 bae = GameObject.FindWithTag("Player").transform.position;
		if(bae != null)
		{
		
		
			if(Vector2.Distance(body.transform.position, bae)<3.0)//It's set so that if the distance is < 3.0 it won't try to approach her.
			{
				return true;
			}
			else{
				return false;
			}
		}
		Debug.Log("Player instance is null in RunToward.");
		return false;
		
	}

	
	
	private void getMoving(string input)
	{
		LayerMask mask = LayerMask.GetMask("Ground");
		Vector2 bae = GameObject.FindWithTag("Player").transform.position;
		hit = Physics2D.Raycast(body.position, new Vector2(0, -1), 1, mask);
		if(hit.collider == null)
		{
			body.velocity = new Vector2(0, -20);
		}
		if(tooClose())
		{
			//do nothing...
		}
		else
		{
			if(input.Contains("Right"))
			{
				body.velocity = body.transform.right * speed;
			}
			else if(input.Contains("Left"))
			{
				body.velocity = body.transform.right * -1 * speed;
			}
		}
	}
}
