using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Volume{
    public static float volume_level;

    void Start(){
        volume_level = 1;
    }

    public float get_volume(){
        return volume_level;
    }

}