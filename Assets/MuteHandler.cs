using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteHandler : MonoBehaviour
{

private bool status;

public Button target;
/* 
public Image volumeNeutral;
public Sprite volumeHighlight;
public Sprite volumePressed;
public Image mutedNeutral;
public Sprite mutedHighlight;
public Sprite mutedPressed;*/

public SpriteState unMuted = new SpriteState();
public SpriteState muted = new SpriteState();
public AudioSource audioSource;

    void Start()
    {   
        target.spriteState = unMuted;
        status = false;
    }

    void Update()
    {
        if (status)
        {
            audioSource.Pause();
            target.spriteState = muted;
        } else{
            audioSource.UnPause();
            target.spriteState = unMuted;
        }
    }

    public void OnMouseDown() 
    {
        status = !status;       
    }
}
