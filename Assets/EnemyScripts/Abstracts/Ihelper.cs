using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ihelper
{
    void setComrade(Ihelper next);
	
	void callLeader(string newRequest);
	
	void handle(string request);
	
}
