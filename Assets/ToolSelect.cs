using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ToolSelect
{

    static int active = 0;
    public static bool[] tools = new bool[3];

    void Start () 
    {
        ToolSelect.tools[0] = true;
        active = 0;
		for(int i = 1; i < 3; i++){
			ToolSelect.tools[i] = false;
		}
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1)) && active != 0)
        {
            tools[0] = true;
            tools[active-1] = false;
            active = 0;

        } else if ((Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2)) && active != 1)
        {
            tools[1] = true;
            tools[active-1] = false;
            active = 1;
        } else if ((Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3)) && active != 2)
        {
            tools[2] = true;
            tools[active-1] = false;
            active = 2;
        }
    }

    public static int getTool()
    {
        return active;
    }
}