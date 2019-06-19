using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : Helper
{
	
	public AbsState[] states = new AbsState[3];//to be adjusted as we change the number of enemy states in game. 3 is probably plenty.
	
	
	public void setState(AbsState input)
	{
		for(int i = 0; i<states.Length; i++)
		{
			if(states[i] == null)
			{
				states[i] = input;
			}
		}
	}
	
   public override void handle(string request)// brain only handles requests regarding state change. states are all contained within the brain which then
   //changes which is in control of commands. Helpers that are specialized to change state (if checkDistance detects a player nearby it tells brain to switch to
   //Chase instead of Patrol).
   {
	   Debug.Log("handle in Brain");
	   if(request.Contains("state"))
	   {
		   changeState("request");
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
	   
	   void inner(string newState)//changes the leader of the states array.
	{
		AbsState[] temp = new AbsState[states.Length];
		AbsState[] tempSingle = new AbsState[1];
		for( int i=0;i<states.Length;i++)//this may have a bug. Definitely check if states aren't changing properly.
		{
			if(states[0].isThis(newState)) 
			{
				break;
			}
			else if(states[i].isThis(newState))
			{
				tempSingle[0] = states[0];
				temp[0] = states[i];
				temp[i] = tempSingle[0];
			}
			else
			{
				temp[i] = states[i];
			}
		}
		
		states = temp;
		
	}
	   
	   
	   
	}
	
	
}
