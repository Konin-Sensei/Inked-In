using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpike : MonoBehaviour
{
  public Rigidbody2D body;
  public BoxCollider2D trig;
  

  Vector2 down = new Vector2(0, -1);
  Vector2 up = new Vector2(0, 1);
  
  void OnTriggerEnter2D(Collider2D other)
  {
	  getGoing();
  }
  
  
  void getGoing()
  {
	
	body.velocity = down;
  }
}
