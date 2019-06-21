using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : AbsState
{
   public override bool isThis(string input)
	{
		if(string.Equals(input, "Patrol"))
		{
			return true;
		}
		return false;
	}
	
	public string getName()
	{
		return "Patrol";
	}

    // Update is called once per frame
}
