using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToward : Helper, Ihelper
{
	private int speed;
	private Rigidbody2D body;
	
		public void setSpeed(int input)
	{
		speed = input;
	}
	
	public RunToward(string input)
	{
		job = input;
	}
	
	public void setBody(Rigidbody2D input)
	{
		body = input;
	}
	
    public override void handle(string request)
	{
		
		
		if(request.Contains(job))//contains the word RunToward but also contains a direction (Right or Left)
		{
			Debug.Log("we called getMoving");
			getMoving(job);
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
	
	private void getMoving(string input)
	{
		if(input.Contains("Right"))
		{
			Debug.Log("WE CALLED RUN RIGHT AND IT DIDN'T WORK I GUESS");
			body.velocity = body.transform.right * speed;
		}
		else
		{
			body.velocity = body.transform.right * -1 * speed;
		}
		
	}
}
