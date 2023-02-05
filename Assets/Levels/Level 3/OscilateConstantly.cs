using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilateConstantly : MonoBehaviour
{
  
    void Start()
    {
        oscillate();
    }
	
	   public void oscillate(){
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * Mathf.Cos(Time.time), 0);
            transform.position = desiredPosition;
	   }
}
