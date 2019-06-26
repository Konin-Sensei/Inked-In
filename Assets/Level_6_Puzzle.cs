using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_6_Puzzle : MonoBehaviour
{
    public GameObject door;
    public bool isTrap;
    public GameObject trap;

    void Start(){
        door.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            door.SetActive(false);
        }
        if(isTrap){
            Vector3 trap_offset = new Vector3(door.transform.position.x, door.transform.position.y - 1f, 0);
            GameObject trap_copy = Instantiate(trap, trap_offset, transform.rotation) as GameObject;
            isTrap = false;
        }
    }
}
