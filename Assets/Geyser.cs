using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    public float duration;
    public float height;
    public float interval;
    public float speed;
	public Geyser parent;
	public Geyser child;
    float Timer;
    Vector3 restPosition;
    bool isUp;
    bool hasOscillated;
    float oscillation_length;
    void Start(){
        Timer = interval;
        restPosition = transform.position;
        isUp = false;
        oscillation_length = duration;
        hasOscillated = false;
    }

    void FixedUpdate(){
        if((Timer <= 0) && ((child == null) || (child.isUp))){//either, the timer is 0 and there's no parent (just one geyser) or the parent is already up so we can start
            activate_geyser();
        }
        else if((parent == null) && isUp){//you need to be the topmost geyser to oscillate
            oscillate();
        }
        else if(hasOscillated){
            deactivate_geyser();
        }else{
            Timer -= Time.deltaTime;
        }
    }

    void activate_geyser(){
        Vector3 desiredPosition = new Vector3(restPosition.x, restPosition.y + height, 0);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        transform.position = smoothedPosition;
        if(Vector3.Distance(transform.position, desiredPosition) < 0.4){
            Timer = interval;
            isUp = true;
        }
    }

    void oscillate(){
        if(oscillation_length > 0){
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * Mathf.Cos(Time.time), 0);
            transform.position = desiredPosition;
            oscillation_length -= Time.deltaTime;
        }else{
            isUp = false;
            hasOscillated = true;
            oscillation_length = duration;
			if(child != null)
			{
				packUpAndGo();
			}
        }
    }

    void deactivate_geyser(){
        Vector3 desiredPosition = new Vector3(restPosition.x, restPosition.y, 0);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        transform.position = smoothedPosition;
        if(Vector3.Distance(transform.position, desiredPosition) < 0.4){
            hasOscillated = false;
        }
    }
	
	void packUpAndGo()
	{
		hasOscillated = true;
		if(child != null)
			child.packUpAndGo();
	}
}
