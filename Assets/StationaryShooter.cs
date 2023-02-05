using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryShooter : MonoBehaviour
{
    public Transform target;
    public GameObject projectile;
    private GameObject projectile_clone;
    public float fire_rate;
    private float Timer;
    public PolygonCollider2D polygon_collider;

    void Start(){
        Timer = fire_rate;
    }

    public void active(Collider2D other){
        if(other.tag == "Player"){
            Timer -= Time.deltaTime;
            float x;
            float y;
            x = target.position.x - transform.position.x;
            y = target.position.y - transform.position.y;
            float angle;
            angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
            if(Timer <= 0){
                fire_projectile();
                Timer = fire_rate;
            }
        }
    }

    void fire_projectile(){
        projectile_clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        projectile_clone.GetComponent<DirectedBullet>().target = target;
    }
}
