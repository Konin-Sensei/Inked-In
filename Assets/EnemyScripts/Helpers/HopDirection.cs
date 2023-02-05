using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopDirection : Helper, Ihelper
{
	private string direction = "Right";
	
	public override void handle(string request)
	{
		
		if(request.Contains("edge") || request.Contains("turn"))
		{
			switchDirections();
		}
		else if(request.Contains("hop"))
		{
			callLeader(direction);
		}
		else
		{
			if(comrade != null)
			{
				comrade.handle(request);
			}
			else
			{
				Debug.Log("HopDirection.handle(string) '" + request + "' helper not found.");
			}
		}
	}
	
	public void switchDirections()
	{
		if(direction.Contains("Right"))
		{
			direction = "Left";
			callLeader("Left");
		}
		else
		{
			direction = "Right";
			callLeader("Right");
		}
	}
	
}
