using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCollider : MonoBehaviour
{
    private PolygonCollider2D polygon_collider;
    public GameObject shooter;
    void Start(){
        polygon_collider = GetComponent<PolygonCollider2D>();
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.tag =="Player"){
            shooter.GetComponent<StationaryShooter>().active(other);
        }
    }
}
