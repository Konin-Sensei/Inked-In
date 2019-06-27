using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{

    public Slider mainSlider;

    // Start is called before the first frame update
    void Start()
    {
        Volume.volume_level = mainSlider.value;
        mainSlider.onValueChanged.AddListener(delegate {changeVolume();});
        
    }

    void changeVolume() 
    {
        Volume.volume_level = mainSlider.value;
    }



    
}
