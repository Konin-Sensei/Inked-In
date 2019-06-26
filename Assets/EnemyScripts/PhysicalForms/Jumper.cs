using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
	public BoxCollider2D col;
	public Rigidbody2D body;
	public Brain brain;
	public Chase chase;
	public Patrol patrol;
	public Look4Player patrolEyes;//basically a hoppingEyes and a patrolToChase put together.
	public Check4Edge edgeEyes;
	public Hop hopLegs;
	public HopDirection hopD;
	
	public float raycast_length;
	public int speed;//thinking they'll just have a constant x velocity
	public int ups;
	public int followDist;
//the next bits are jump specific movement stuff. I know we'll need jumping. Probs just a longer raycast to deal with edge avoidance



	
	
	
      // Start is called before the first frame update
    public void Start()
    {

        body.gravityScale = 3.5f;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;


		
		col = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
		
		hopD = new HopDirection();
		patrolEyes = new Look4Player("lookForPlayer");
		brain = new Brain();
		chase = new Chase();
		patrol = new Patrol();
		edgeEyes = new Check4Edge("checkEdges");
		hopLegs = new Hop();

		
		brain.setState(patrol);
		brain.setState(chase);
		
		patrol.setJob("lookForPlayer");
		patrol.setJob("checkEdges");
		patrol.setJob("hop");

		
		brain.setComrade(patrolEyes);
		patrolEyes.setComrade(edgeEyes);
		edgeEyes.setComrade(hopD);
		hopD.setComrade(hopLegs);

		
		hopLegs.setLeader(brain);
		patrolEyes.setLeader(brain);
		hopD.setLeader(hopLegs);
		edgeEyes.setLeader(brain);
		
		

		
		edgeEyes.setBody(body);
		hopLegs.setBody(body);
		patrolEyes.setBody(body);

		
		hopLegs.setSpeed(speed);
		hopLegs.setHeight(ups);
		patrolEyes.setFollowDist(followDist);
		edgeEyes.set_raycast_length(raycast_length);
		
    }

    // Update is called once per frame
    void Update()
    {
		brain.Update();
    }
}
