using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TitleSplash : MonoBehaviour
{
    public float FadeRate;
    private Image image;
    private float targetAlpha;

    void Start(){
        this.image = this.GetComponent<Image>();
        if(this.image == null){
            Debug.LogError("Error: No Image on "+this.name);
        }
        this.targetAlpha = this.image.color.a;
        FadeIn();
        FadeOut();
    }

    void Update(){
        Color curColor = this.image.color;
        float alphaDiff = Math.Abs(curColor.a - this.targetAlpha);
        if(alphaDiff > 0.0001f){
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, this.FadeRate * Time.deltaTime);
            this.image.color = curColor;
        }
    }

    public void FadeOut(){
        this.targetAlpha = 0.0f;
    }

    public void FadeIn(){
        this.targetAlpha = 1.0f;
    }
}
