using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    SpriteRenderer sprite_renderer;
    public Sprite[] open_sprites = new Sprite[9];
    public Sprite[] closed_sprites = new Sprite[9];

    void Start(){
        sprite_renderer = GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = closed_sprites[ColorProgress.getLevel()];
    }

    void OnTriggerEnter2D(Collider2D other){
        sprite_renderer.sprite = open_sprites[ColorProgress.getLevel()];
    }

    void OnTriggerExit2D(Collider2D other){
        sprite_renderer.sprite = closed_sprites[ColorProgress.getLevel()];
    }
}
