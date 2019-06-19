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
	public checkCollision chkr; //chkr
		
	
    // Start is called before the first frame update
    public void Start()
    {

        body.gravityScale = 3.5f;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;


        // BoxCollider2D
        col.size = new Vector2(1, 1.5f);
        col.offset = new Vector2(0, -0.25f);
		
		col = GetComponent<BoxCollider2D>();
		col.size = new Vector2(1, 2.5f);
        body = GetComponent<Rigidbody2D>();
		brain = new Brain();
		chkr = new checkCollision("checkCollisions");
		chase = new Chase();
		patrol = new Patrol();
		walkHelp = new walk("walkToFarthestEdge");
		brain.setState(patrol);
		brain.setState(chase);
		patrol.setJob("walkToFarthestEdge");//this should probably be separate from runToPlayer, and slower than that. Should walk to edge of plat.
		patrol.setJob("checkCollisions");//checks if current velocity is 0
		chase.setJob("runToPlayer");
		chase.setJob("jumpToNextLedge");//will make them go up or down.
		brain.setComrade(walkHelp);
		walkHelp.setComrade(chkr);
		walkHelp.setLeader(brain);
		chkr.setLeader(brain);
		chkr.setBod(body);
		walkHelp.setBody(body);
		Debug.Log("solid");
		
    }
	
	void Update()
	{
		
		//Debug.Log(brain.getState());//uncomment when you need to know the current state of brain.
		brain.Update();
	}




}
