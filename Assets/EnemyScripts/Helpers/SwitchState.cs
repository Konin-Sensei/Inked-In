using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchState : Helper, Ihelper//this class is set up so that for every state, if a Helper says something that should change the state, it changes it accordingly.
{
   private string[] trigger = new string[5];
   private string stateCall;
   
   public void addResponse(string input)
   {
	   stateCall = input;
   }
   
   public void addTrigger(string input)
   {
	   for(int i = 0; i<trigger.Length; i++)
	   {
		   if(trigger[i] == null)
		   {
			   trigger[i] = input;
			   break;
		   }
	   }
   }
   
   public override void handle(string input)
   {
	   for(int i = 0; i<trigger.Length; i++)
	   {
		   if(trigger[i].Contains(input))
		   {
			   callLeader(stateCall);
			   break;
		   }
	   }
   }
}
