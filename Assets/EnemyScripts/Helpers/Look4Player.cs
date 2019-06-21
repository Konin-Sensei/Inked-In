using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look4Player : Helper, Ihelper
{
	private Rigidbody2D body;
	private int followDist;//distance at which the guy looses sight of the player or chases/continueschasing. To be adjusted!
	
	public Look4Player(string input)
	{
		job = input;
	}
	
	public void setFollowDist(int input)
	{
		followDist = input;
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
				Debug.Log("Look4Player.handle(string) '" + request + "' helper not found.");
			}
		}
	}
	
	private void lookAbout()
	{
		Vector3 playerLoc = GameObject.FindWithTag("Player").transform.position;
		Vector3 myLoc = body.transform.position;
		if(playerLoc == null)
		{
			Debug.Log("playerLoc in Look4Player is null!");
			//do nothing...
		}
		else
		{
			Vector2 pPos = new Vector2(playerLoc.x, playerLoc.y);
			Vector2 mPos = new Vector2(myLoc.x, myLoc.y);
			if(Vector2.Distance(mPos, pPos) < followDist)
			{
				callLeader("stateChase");

			}
			else
			{
				//do nothing...
			}
		}
	}
    
}
