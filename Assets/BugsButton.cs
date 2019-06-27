using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugsButton : MonoBehaviour
{
    public GameObject[] doors1 = new GameObject[2];
    public GameObject[] doors2 = new GameObject[2];

    void Start(){
        doors1[0].SetActive(true);
        doors1[1].SetActive(true);
        doors2[0].SetActive(false);
        doors2[1].SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            doors1[0].SetActive(false);
            doors1[1].SetActive(false);
            doors2[0].SetActive(true);
            doors2[1].SetActive(true);
        }
    }
}
