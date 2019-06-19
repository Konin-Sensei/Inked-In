using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : AbsState
{
   public override bool isThis(string input)
	{
		if(string.Equals(input, "Chase"))
		{
			return true;
		}
		return false;
	}

	public string getName()
	{
		return "chase";
	}

}
