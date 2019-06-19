using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoController : MonoBehaviour
{
    SpriteRenderer sprite_renderer;
    public Sprite[] sprites = new Sprite[10];

    void Start(){
        sprite_renderer = GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = sprites[ColorProgress.getLevel()];
    }
}
