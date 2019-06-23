using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollision : Helper, Ihelper//There's still an issue with this method not working well with faster enemies, but honestly I'm not worried about that rn.
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
		if(request.Contains(job))
		{
			if(stopped())
			{
				callLeader("turn");
			}
		}
		else
		{
			if(comrade != null)
			{
				comrade.handle(request);
			}
			else
			{
				Debug.Log("checkCollision.handle(string) '" + request + "' helper not found.");
			}
		}
	}
	
	public bool stopped()
	{
		if(Mathf.Abs(xpos - body.position.x) < 0.02)//this is the value for how much it must move at least for it not to think it's stopped.
		{
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