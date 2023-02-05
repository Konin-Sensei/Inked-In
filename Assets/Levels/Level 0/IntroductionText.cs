using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionText : MonoBehaviour
{
    public Text textbox;
    
    void Start(){
        textbox.text = "Welcome to Inked-In!\nTo begin, lets try moving left and\nright using the A & D keys or the \n             left & right arrow keys.";  
    }

    public void setText(string text){
        textbox.text = text;
    }
}
