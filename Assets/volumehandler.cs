using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumehandler : MonoBehaviour
{

    void Start(){
        Volume.volume_level = 1;
    }
    // Start is called before the first frame update
    void Update(){
        gameObject.GetComponent<AudioSource>().volume = Volume.volume_level;
    }
}
