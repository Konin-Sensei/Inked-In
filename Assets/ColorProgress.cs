using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ColorProgress{
    public static bool[] level = new bool[10];

    public static int getLevel(){
        for(int i = 9; i >= 0; i--){
            if(level[i]){
                return i;
            }
        }
        return 8;
    }
}

class Tool{
    public static bool[] tools = new bool[3];

    public static int getTool(){
        return 1;

    }
}
