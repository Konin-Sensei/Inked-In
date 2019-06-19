using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : AbsState
{
    public override bool isThis(string input)
	{
		if(string.Equals(input, "Rest"))
		{
			return true;
		}
		return false;
	}
	
	public string getName()
	{
		return "rest";
	}

 
}
