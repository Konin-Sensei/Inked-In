using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staybox : MonoBehaviour
{
    public int level;
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            for(int i = 0; i < 9; i++){
                if(i == level){
                    BossProgress.level[i] = true;
                }else{
                    BossProgress.level[i] = false;
                }
            }
        }
    }
}
