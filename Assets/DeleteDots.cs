using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDots : MonoBehaviour
{
    void Start(){

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
         {
             Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
             RaycastHit2D[] hits = Physics2D.CircleCastAll(mousePos, 1f, Vector2.zero, 100f);
             foreach(RaycastHit2D hit in hits){
                if(hit.collider != null)
                {
                    if(hit.transform.gameObject.tag == "Dots")
                        Destroy(hit.transform.gameObject);
                }
             }
         }
    }
}
