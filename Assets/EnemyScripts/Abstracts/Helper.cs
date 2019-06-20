using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Helper : Ihelper
{
	public string job;
	protected Ihelper leader;//this is the brain which is the first link in the Chain of Responsibility
	protected Ihelper comrade;//this is the next Helper in The Chain.
	
	
	

	public void setLeader(Ihelper leaderParam)//factory will set globals. (if there's some sorta protected value for C# we should probs use it...
	{
		leader = leaderParam;
	}
	
	
	public void setComrade(Ihelper comradeParam)
	{
		if(comrade != null)
		{
			comrade.setComrade(comradeParam);
		}
		else
		{
			comrade = comradeParam;
		}
	}
	
	public void callLeader(string newRequest)
	{
		if(leader != null)
		{
		//Helper class can decide to call a follow-up request ex: legs may handle jumping but will inevitably call an animateJump request as well.
		leader.handle(newRequest);
		}
	}
	
	public abstract void handle(string request);//public function to allow private code to be called when needed.
	//{
	//	if(request == job)
	//	{
	//		this is where we call private functions
	//	}
	//}
	
	
	//private output ability/feature/function() private function containing actual object functionality.
	//{
		//things this helper does in response to a call.
	//}
}
