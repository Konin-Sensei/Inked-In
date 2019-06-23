using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunDirection : Helper, Ihelper
{
	private Rigidbody2D body;
	
	public RunDirection(string input)
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
			lookAbout();
		}
		else
		{
			if(comrade != null)
			{
				comrade.handle(request);
			}
			else
			{
				Debug.Log("RunDirection.handle(string) '" + request + "' helper not found.");
			}
		}
	}
	
	private void lookAbout()
	{
		Vector3 playerLoc = GameObject.FindWithTag("Player").transform.position;
		Vector3 myLoc = body.transform.position;
		if(playerLoc == null)
		{
			Debug.Log("playerLoc in RunDirection is null!");
			//do nothing...
		}
		else
		{
			if(playerLoc.x > myLoc.x)
			{
				callLeader("Right");

			}
			else
			{
				callLeader("Left");
			}
		}
	}
	
}
