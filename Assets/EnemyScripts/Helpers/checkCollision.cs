using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollision : Helper, Ihelper
{
    private Rigidbody2D body;
	private float xpos;
	
	public checkCollision(string input)
	{
		job = input;
	}
	
	public void setBod(Rigidbody2D input)
	{
		body = input;
	}
	
	
	
	public override void handle(string request)//looking to find a better way to judge movement/time
	{
		Debug.Log("chkr.handle was called!");
		if(request.Contains(job))
		{
			if(stopped())
			{
				callLeader("turn");
			}
			else
			{
				//do nothing
			}
		}
	}
	
	public bool stopped()
	{
		Debug.Log(xpos + " " + body.position.x);
		if(xpos == body.position.x)
		{
			Debug.Log("bodyStopped!");
			return true;
		}
		else
		{
			xpos = body.position.x;
			return false;
		}
	}

}


//check to see if velocity is 0
//if so, throw some sorta change direction shit on the thingstodolist
//that's a for now thing

//in the future, I'd like it to just know if the wall in front of it is low enough to jump to
//this would require a very well aimed raycastHit2D with a very well aimed jump. 