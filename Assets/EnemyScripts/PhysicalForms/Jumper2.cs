using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper2 : MonoBehaviour
{
	public Rigidbody2D body;
	public int followDist;
	public int speed;
	public int height;
	private RaycastHit2D hit;
	private bool chasing = false;
	
	void Update()
	{
		if(!chasing)
		{
			lookAbout();
			goRandDir();
			checkLife();
			
		}
		else
		{
			chasePlayer();
		}
	}
	
	private void checkLife()
	{
		if(gameObject.transform.position.y < -100)
		{
			Destroy(gameObject);//THE CIRCLE OF LIIIIIIIIIIIIIIIIIIIIIIIIIIIIIFEEEEEEEEE
		}
	}
	
	private void makeBaby()
	{
		int slimeNumAtTheTime = SlimeCap.slimeCount;
		int dieRoll = Random.Range(1, slimeNumAtTheTime);//six sided die
		if((dieRoll == 6) && (slimeNumAtTheTime < 60))
		{
			
			SlimeCap.slimeCount++;
			Instantiate(gameObject, transform.position, transform.rotation);
		}
					Debug.Log(slimeNumAtTheTime + " " + dieRoll);

	}
	
	private void lookAbout()//tries to find player; we set the max "sight" range 
	{
		Vector3 playerLoc = GameObject.FindWithTag("Player").transform.position;
		Vector3 myLoc = body.transform.position;
		if(playerLoc == null)
		{
			Debug.Log("playerLoc in jumper2 is null!");
			//do nothing...
		}
		else
		{
			Vector2 pPos = new Vector2(playerLoc.x, playerLoc.y);
			Vector2 mPos = new Vector2(myLoc.x, myLoc.y);
			if(Vector2.Distance(mPos, pPos) <= followDist)
			{
				chasing = true;

			}
			else
			{
				//do nothing...
			}
		}
	}
	
	public void chasePlayer()//nothing really set to make them stop chasing the player but whatevs; they're not very good at chasing anyways...
	{
		Vector2 playerLoc = GameObject.FindWithTag("Player").transform.position;
		Vector2 myLoc = body.transform.position;
		if(playerLoc == null)
		{
			Debug.Log("playerLoc in jumper2 is null!");
			//do nothing...
		}
		else
		{
			if(playerLoc.x > myLoc.x)
			{
				fallingQuestionMark("Right");
			}
			else
			{
				fallingQuestionMark("Left");
			}
		}
	}
	
	public void goRandDir()//randomly hops left or right if not chasing player
	{
		int zeroOrOne = Random.Range(0, 2);//[0, 2)
		if(zeroOrOne == 1)
			fallingQuestionMark("Right");
		else
			fallingQuestionMark("Left");
		
	}
	
	public void fallingQuestionMark(string request)//doesn't hop if falling (no double jumps
	{
		LayerMask mask = LayerMask.GetMask("Ground");
		Vector2 straightDown = new Vector2(0, -1);
		hit = Physics2D.Raycast(body.position, straightDown, 1, mask);
		if(hit.collider != null)
		{
			hop(request);
			makeBaby();
		}
	}
	
	public void hop(string direction)//hops based on inputs that we'll set
	{
		Vector2 jumpRight = new Vector2(speed, height);
		Vector2 jumpLeft = new Vector2(-1 * speed, height);
		if(direction.Contains("Right"))
		{
			body.velocity = jumpRight;
		}
		else
		{
			body.velocity = jumpLeft;
		}
	}
}
