using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public string level_name;
    public int level_index;
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            SceneManager.LoadScene(level_name);
            if(ColorProgress.getLevel() != 9)
                ColorProgress.level[level_index] = false;
        }
    }
}
