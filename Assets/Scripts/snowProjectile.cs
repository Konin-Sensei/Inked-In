using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowProjectile : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[3];
    private Transform player;
    private SpriteRenderer spriterenderer;
    private float Timer;
    public float speed;
    private Vector3 enemyPos;
    public float detectionRadius;
    public float Range;
    public GameObject projectile;
    GameObject projectile_clone;

    // Start is called before the first frame update
    void Start(){
        spriterenderer = GetComponent<SpriteRenderer>();
        enemyPos = transform.position;
        Timer = Range;
        GameObject player_obj = GameObject.Find("UnityChan V2");
        player = player_obj.transform;
    }

    // Update is called once per frame
    void Update(){
        if(Mathf.Abs(Vector3.Distance(transform.position, player.position)) < detectionRadius){
            ChasePlayer();
            AnimateSnowball();
            Timer -= Time.deltaTime;
            if(Timer < 0.1){
                Destroy(gameObject);
            }
        }
    }

    void ChasePlayer(){
        Vector3 desiredPos = Vector3.Lerp(transform.position, player.position, speed *Time.deltaTime);
        transform.position = desiredPos;
    }

    void AnimateSnowball(){
        if(transform.position.y - player.position.y > 0.5f){
            spriterenderer.sprite = sprites[1];
        }else if(transform.position.y - player.position.y < -0.5f){
            spriterenderer.sprite = sprites[2];
        }else{
            spriterenderer.sprite = sprites[0];
        }
        if(transform.position.x - player.position.x > 0 && spriterenderer.flipX){
            spriterenderer.flipX = false;
        }else if(transform.position.x - player.position.x < 0 && !spriterenderer.flipX){
            spriterenderer.flipX = true;
        }
    }
}
