using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public void setProgress ()
    {
        for(int i =0; i< 9; i++)
            ColorProgress.level[i] = true;
    }

}
