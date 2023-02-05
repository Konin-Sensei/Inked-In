using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check4Edge: Helper, Ihelper
{
	private Rigidbody2D body;
	private float raycast_length;
		private RaycastHit2D hit;

	
	public Check4Edge(string input)
	{
		job = input;
	}
	
	public void set_raycast_length(float length_in)
	{
		raycast_length = length_in;

	}
	
	public void setBody(Rigidbody2D input)
	{
		body = input;
	}
	
	public override void handle(string request)
	{
		

		if(request.Contains("Right") || request.Contains("Left") || request.Contains(job))//contains the word Right or Left
		{
			checkEdges(request);
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
	
		private void checkEdges(string request) //will see if we're too close to the edge and let the brain no.
	{
		LayerMask mask = LayerMask.GetMask("Ground");
		Vector2 downRight = new Vector2(1, -1);
		Vector2 downLeft = new Vector2(-1, -1);
		if(request.Contains("Right"))
		{
			hit = Physics2D.Raycast(body.position, downRight, raycast_length, mask);
		}
		else
		{
			hit = Physics2D.Raycast(body.position, downLeft, raycast_length, mask);	
		}
		
		
		if(hit.collider == null)
		{
			callLeader("edge");
		}
		else
		{
			//continue moving in same direction.
		}
		
	}
	
	//So this needs to be filled in
	//then we need a class that checks if stopped (if stopped 
	//both of these messages get sent to brain
	//there needs to be two classes that handle stopped-body and handle reachedEdge
		//for both of these in the walker, the stopChasing class will just make it switch to patrol
	//flying enemies are next and just use cosin to make them fly around (adding cosin to the y so it goes up and down)
}
