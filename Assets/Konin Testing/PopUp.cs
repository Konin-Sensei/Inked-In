using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
	public float addedHeight;
	public float speed;//should be a fraction or else it flies.
	public float maxHeight;
	private float minHeight;
	public BoxCollider2D coll;
	public Rigidbody2D body;
	public float timer;
	private float reference;
	private bool goingDown = false;
	private bool wobbling = false;
	//konin
	/*public float k_height;
	public float k_init_timer;
	private float k_timer;
	public float k_duration;
	*/
	void Start()
	{
		reference = timer;
		minHeight = body.transform.position.y;
	}
	
	public void setTimer(float input)
	{
		timer = input;
	}
	
	public void setSpeed(float input)
	{
		speed = input;
	}
	
	public void setAddedHeight(float input)
	{
		addedHeight = input;
	}
	
	public void setMaxHeight(float input)
	{
		maxHeight = input;
	}
	
	
	public void setCol(BoxCollider2D input)
	{
		coll = input;
	}
	
	public void setBody(Rigidbody2D input)
	{
		body = input;
	}
 
	void Update()
    {
		float tempy = body.transform.position.y;
		if(tempy > maxHeight && !goingDown && (timer < 0))
		{
			Debug.Log("set it to true");
			goingDown = true;
		}
		else if(tempy < (maxHeight - 1) && !goingDown)
		{
			Debug.Log("goUp()");
			goUp();
		}
		else if(tempy> maxHeight && goingDown)
		{
			Debug.Log("goDown()");
			goDown();
		}
		else if((((maxHeight - 1) < tempy) && (tempy < maxHeight) && (!goingDown)) || wobbling)
		{
			Debug.Log("wobble()");
			wobbling = true;
			wobble();
		}
		else if(goingDown && tempy < minHeight)
		{
			Debug.Log("false");
			goingDown = false;
		}
	}
		
		//Konin
		/*k_timer -= Time.deltaTime;
		if(k_timer <= 0){
			Vector3 desiredPos = new Vector3(transform.position.x, transform.position.y + k_height, 0);
			while(Mathf.Abs(Vector3.Distance(transform.position, desiredPos)) > 0.1){
				Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime);
				transform.position = smoothedPos;
			}
			float new_timer = k_duration;
			while(new_timer >= 0){
				k_oscillate();
			}
			desiredPos = new Vector3(transform.position.x, transform.position.y - k_height, 0);
			while(Mathf.Abs(Vector3.Distance(transform.position, desiredPos)) > 0.1){
				Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime);
				transform.position = smoothedPos;
			}
			
			
				
		}
			
		
    }
	public void k_oscillate(){
		transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Cos(Time.time), 0);
	}*/
	

	
	public void wobble()
	{
		Debug.Log(timer);
		timer -= Time.deltaTime;
		Debug.Log(timer);
		float tempx = body.transform.position.x;
		float tempy = body.transform.position.y;
		Debug.Log(Mathf.Sin(Time.time));
		float uppity = tempy + (Mathf.Sin(Time.time));
		body.transform.position = new Vector2(tempx, uppity);
		if(timer < 0)
		{
			goingDown = true;
			wobbling = false;
		}
	}
	
	public void goUp()
	{
		float tempx = body.transform.position.x;
		float tempy = body.transform.position.y;
		body.transform.position = new Vector2(tempx, tempy + addedHeight);

	}
	
	public void goDown()
	{
		float tempx = body.transform.position.x;
		float tempy = body.transform.position.y;
		body.transform.position = new Vector2(tempx, tempy - addedHeight);
	}

	
}
