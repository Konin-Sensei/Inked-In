using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hop : Helper, Ihelper
{
    private int speed;
	private int height;
	private Rigidbody2D body;
	private RaycastHit2D hit;
	
	public void setHeight(int input)
	{
		height = input;
	}
	
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
		Debug.Log(request);
		
		callLeader(request);//this is to let the check4edges class know which direction we're moving.

		if(request.Contains("Right") || request.Contains("Left"))//contains the word Right or Left
		{
			fallingQuestionMark(request);
		}
		else
		{
			if(comrade != null)
			{
				comrade.handle(request);
			}
			else
			{
				Debug.Log("Hop.handle(string) '" + request + "' helper not found.");
			}
		}
		
	}
	
	public void fallingQuestionMark(string request)
	{
		LayerMask mask = LayerMask.GetMask("Ground");
		Vector2 straightDown = new Vector2(0, -1);
		hit = Physics2D.Raycast(body.position, straightDown, 1, mask);
		if(hit.collider != null)
		{
			hop(request);
		}
	}
	
	public void hop(string direction)
	{
		Vector2 jumpRight = new Vector2(speed, height);
		Vector2 jumpLeft = new Vector2(-1 * speed, height);
		if(direction.Contains("Right"))
		{
			body.velocity = jumpRight;
		}
		else
		{
			body.velocity = jumpLeft;
		}
	}
}
