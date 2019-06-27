using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerOfWorlds : MonoBehaviour
{	
	 void OnTriggerEnter2D(Collider2D other)
	 {
		 Destroy(other);
	 }//the idea was to run from this guy to make the game slightly more interesting. A smarter player could try and trigger the trap on the enemy to end that
	 //hazard. Issue being the actual implementation of a trap, which I cannot do at this point, mentally.
	
}
