using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : AbsState
{
	private string name = "Chase";
	
   public override bool isThis(string input)
	{
		if(input.Contains(name))
		{
			return true;
		}
		return false;
	}

	public string getName()
	{
		return "Chase";
	}

}
