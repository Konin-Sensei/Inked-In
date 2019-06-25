using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicHandler : MonoBehaviour
{
    public static MusicHandler music_source;
    void Awake(){
        if(music_source){
            DestroyImmediate(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
            music_source = this;
        }
        
    }
}
