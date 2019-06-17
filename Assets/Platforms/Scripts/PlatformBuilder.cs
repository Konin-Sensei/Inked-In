using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class PlatformBuilder : MonoBehaviour
{
    public Platform platform;

    private Sprite display_design;
    private BoxCollider2D box_collider;
    private SpriteRenderer sprite_renderer;

    void Reset(){
        Awake();
    }

    void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        gameObject.layer = LayerMask.NameToLayer("Ground");
        box_collider = GetComponent<BoxCollider2D> ();
        sprite_renderer = GetComponent<SpriteRenderer> ();
        sprite_renderer.sprite = platform.platform_design;
        scale_collider();
    }

    void scale_collider(){
        Vector2 sprite_size = sprite_renderer.sprite.bounds.size;
        box_collider.size = sprite_size;
        box_collider.offset = new Vector2(0, 0);

    }
}
