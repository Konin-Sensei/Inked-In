using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BossProgress{
    public static bool[] level = new bool[10];

    public static int getLevel(){
        for(int i = 9; i >= 0; i--){
            if(level[i]){
                return i;
            }
        }
        return 0;
    }
}