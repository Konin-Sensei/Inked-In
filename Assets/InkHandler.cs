using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkHandler : MonoBehaviour
{
    public int ink_quantity;
    public int ink_used;

    public void decrease_ink(){
        ink_used += 1;
    }

    public bool ink_available(){
        if(ink_quantity - ink_used > 0){
            return true;
        }
        return false;
    }

    public int ink_avail_quantity(){
        print(ink_quantity - ink_used);
        return (ink_quantity - ink_used);
        
    }
}
