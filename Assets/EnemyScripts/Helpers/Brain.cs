using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : Helper
{
	
	public AbsState[] states = new AbsState[3];//to be adjusted as we change the number of enemy states in game. 3 is probably plenty.
	
	
	public void setState(AbsState input)
	{
		for(int i = 0; i<3; i++)
		{
			if(states[i] == null)
			{
				states[i] = input;
				break;
			}
		}
	}
	
   public override void handle(string request)// brain only handles requests regarding state change. states are all contained within the brain that
   //changes which state is in control of commands. Helpers that are specialized to change state (if checkDistance detects a player nearby it tells brain to switch to
   //Chase instead of Patrol).
   {
	   if(request.Contains("state"))
	   {
		   changeState(request);
	   }
	   this.comrade.handle(request);
   }
   
   public AbsState getState()
   {
	   return states[0];
   }
   
       // Update is called once per frame
    public void Update()
    {
        comrade.handle(states[0].nextJob());
    }
   
   private void changeState(string stateRequest)//calls inner with the proper type of state.
   {
	   if(stateRequest.Contains("Patrol"))
	   {
		   inner("Patrol");
	   }
	   else if(stateRequest.Contains("Rest"))
	   {
		   inner("Rest");
	   }
	   else
	   {
		   inner("Chase");
	   }
	   
	   void inner(string newState)//changes the leader of the states array. THIS IS THE PROBLEM MY MAN!
		{
			AbsState[] temp = new AbsState[1];
			if(states[0].isThis(newState)) 
			{
				Debug.Log("We're already in that state I guess");
				//do nothing
			}
			else
			{
				for( int i=0;i<3;i++)
				{
					Debug.Log("we made it to the for loop, so far.");
					if(states[i].isThis(newState))
					{
						Debug.Log("We made it to the for loop and the IF came out true at index = " + i);
						temp[0] = states[i];
						states[i] = states[0];
						states[0] = temp[0];
					}
				}
			}
		}
	   
	   
	   
	}
	
	
}
