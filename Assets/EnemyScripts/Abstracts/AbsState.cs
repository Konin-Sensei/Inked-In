using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is the parent class of all states. They're supposed to hold the strings calling the features that will be needed at certain times. Patrol, for example, holds 
//a string for walking back and forth, and a string for looking. These classes keep track of the order of using these abilities (usually just one after another) and 
//set up a sort of separation that will hopefully make things easier. If not, we could always replace them with 2d string arrays...
public abstract class AbsState
{
	protected Helper subscriber;
	private int counter = 0;
    private string[] actions = new string[5];//this is set to 5 right now but we could also increase it or set it to change length automagically. 
	
	public void setSub(Helper subParam)
	{
		subscriber = subParam;
	}
	
	public abstract bool isThis(string name);
	
	public void setJob(string job)
	{
		for(int i = 0; i< actions.Length; i++)
		{
			if(actions[i] == null)
			{
				actions[i] = job;
				break;
			}
		}
	}
	
	public string nextJob()//returns the next string in the cycle
	{		
		if(counter > 3)
		{
			counter = 0;
		}
		else
		{
		counter++;
		}
		
		if((actions[counter] == null))
		{
			this.nextJob();
		}
		else
		{
			return actions[counter];

		}
		
		return actions[counter] + "nextJobOutput";//so i put this here for testing purposes if it doesn't always lead to output.
		
	}
	
	
	
	
}
