using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkHandler : MonoBehaviour
{
    public int ink_quantity;
    public int ink_used;
    private GameObject ink_canvas;
    private GameObject ink_meter;

    void Awake(){
        ink_canvas = new GameObject();
        ink_meter = new GameObject();
        ink_meter.transform.parent = ink_canvas.transform;
        ink_canvas.AddComponent<Canvas>();
        Canvas meter_canvas = ink_canvas.GetComponent<Canvas>();
        meter_canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        ink_meter.AddComponent<Text>();
        Text meter_text = ink_meter.GetComponent<Text>();
        Material text_material = Resources.Load<Material>("Font Material");
        Font text_font = Resources.Load<Font>("munro");
        meter_text.font = text_font;
        meter_text.fontSize = 42;
        meter_text.material = text_material;
        meter_text.material.color = Color.white;

        RectTransform rect_transform = meter_text.GetComponent<RectTransform>();
        rect_transform.anchoredPosition3D = new Vector3(-171.7f, 26.3f, 0f);
        rect_transform.anchorMin = new Vector2(1f, 0f);
        rect_transform.anchorMax = new Vector2(1f, 0f);
        rect_transform.sizeDelta = new Vector2(343.5f, 52.6f);
        
    }

    void Update(){
        WriteQuantity();
    }

    void WriteQuantity(){
        if(ink_quantity - ink_used < 0){
            ink_meter.GetComponent<Text>().text = "Ink Remaining: 0";
        }else{
            ink_meter.GetComponent<Text>().text = "Ink Remaining: " + (ink_quantity - ink_used).ToString();
        }
        
    }

    public void decrease_ink(){
        ink_used += 1;
    }

    public bool ink_available(){
        if(ink_quantity - ink_used > 0){
            return true;
        }
        return false;
    }

    public int ink_avail_quantity(){
        print(ink_quantity - ink_used);
        return (ink_quantity - ink_used);
        
    }
}
