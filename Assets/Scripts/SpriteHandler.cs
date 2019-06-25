using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[9];
    SpriteRenderer sprite_renderer;
    // Start is called before the first frame update
    void Start(){
        sprite_renderer = GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = sprites[ColorProgress.getLevel()];
    }
    void Update(){
        sprite_renderer.sprite = sprites[ColorProgress.getLevel()];
    }
}
