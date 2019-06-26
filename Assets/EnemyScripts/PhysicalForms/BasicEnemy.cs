using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
//[CreateAssetMenu(fileName = "New RickObject", menuName = "Walker")] would be a thing but I think it has to be a monoB for some reason and so the menu option will have to wait
//we can use prefabs in an enemy folder for the time being.

public class BasicEnemy : MonoBehaviour
{
	public BoxCollider2D col;
	public Rigidbody2D body;
	public Brain brain;
	public Chase chase;
	public Patrol patrol;
	public walk walkHelp;
	public checkCollision chkr; //chkr gets used in both states.
	public Look4Player eyes;
	public RunToward runninLegs;
	public RunDirection runninCompass;
	public Check4Edge runninEyes;
	public SwitchState transition;
	
	public float raycast_length;
	public int sprint;
	public int speed;
	public int followDist;
	
    // Start is called before the first frame update
    public void Start()
    {

        body.gravityScale = 3.5f;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;


        // BoxCollider2D
        //col.size = new Vector2(1, 1.5f);
        //col.offset = new Vector2(0, -0.25f);
		
		col = GetComponent<BoxCollider2D>();
		//col.size = new Vector2(1, 2.5f);
        body = GetComponent<Rigidbody2D>();
		
		runninCompass = new RunDirection("CheckDirection");
		runninLegs = new RunToward();//Doesn't have just one string that it responds to.
		eyes = new Look4Player("lookAround");
		brain = new Brain();
		chkr = new checkCollision("checkCollisions");
		chase = new Chase();
		patrol = new Patrol();
		walkHelp = new walk("walkToFarthestEdge");
		runninEyes = new Check4Edge("Z");
		transition = new SwitchState();
		
		brain.setState(patrol);
		brain.setState(chase);
		
		patrol.setJob("walkToFarthestEdge");//this should probably be separate from runToPlayer, and slower than that. Should walk to edge of plat.
		patrol.setJob("checkCollisions");//checks if current velocity is 0
		patrol.setJob("lookAround");
		chase.setJob("CheckDirection");
		chase.setJob("checkCollisions");
		transition.addTrigger("edge");
		transition.addTrigger("turn");//if checkCollision tells us that we've hit a wall (which usually means turn around) we switch states.
		transition.addResponse("statePatrol");
		
		brain.setComrade(walkHelp);
		brain.setComrade(eyes);
		brain.setComrade(chkr);
		chkr.setComrade(runninCompass);
		chkr.setComrade(runninLegs);
		runninCompass.setComrade(runninEyes);
		runninCompass.setComrade(transition);
		
		walkHelp.setLeader(brain);
		eyes.setLeader(brain);
		chkr.setLeader(brain);
		runninCompass.setLeader(runninLegs);
		runninLegs.setLeader(runninEyes);
		runninEyes.setLeader(brain);
		transition.setLeader(brain);
		
		chkr.setBod(body);
		walkHelp.setBody(body);
		eyes.setBody(body);
		runninLegs.setBody(body);
		runninCompass.setBody(body);
		runninEyes.setBody(body);
		
		runninLegs.setSpeed(sprint);
		walkHelp.setSpeed(speed);
		eyes.setFollowDist(followDist);
		walkHelp.set_raycast_length(raycast_length);
		runninEyes.set_raycast_length(raycast_length);
		
    }
	
	void Update()
	{
		
		//Debug.Log(brain.getState());//uncomment when you need to know the current state of brain.
		brain.Update();
	}




}
