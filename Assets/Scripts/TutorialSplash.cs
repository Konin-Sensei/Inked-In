using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSplash : MonoBehaviour
{
    public float FadeRate;
    private Image image;
    private float targetAlpha;
    public Canvas tutorial_speech;

    // Start is called before the first frame update
    void Start(){
        tutorial_speech.enabled = false;
        this.image = this.GetComponent<Image>();
        if(this.image == null){
            Debug.LogError("Error: No Image on "+this.name);
        }
        this.targetAlpha = this.image.color.a;
        FadeIn();
        FadeOut();
    }

    // Update is called once per frame
    void Update(){
        Color curColor = this.image.color;
        float alphaDiff = Math.Abs(curColor.a - this.targetAlpha);
        if(alphaDiff > 0.0001f){
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, this.FadeRate * Time.deltaTime);
            this.image.color = curColor;
        }
        if(alphaDiff <= 0.03f && tutorial_speech.enabled == false){
            tutorial_speech.enabled = true;
        }
    }

    public void FadeOut(){
        this.targetAlpha = 0.0f;
    }

    public void FadeIn(){
        this.targetAlpha = 1.0f;
    }
}
