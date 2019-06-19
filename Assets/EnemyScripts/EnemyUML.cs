//The solution to creating a lot of enemies that have significant commonalities: Refactoring! 

    // The hope is that this set up will allow us to create features separate from enemies. If a feature falls through (isn't feasible) we can just omit it from 
	//the enemy we had planned it for and use some other features we have in the helper class hierarchy. The abs enemy and concrete enemy class will assure that each
	//enemy has the proper physical properties/features. The state hierarchy will hopefully decrease the amount of logic we have to write (one state class can be used
	//for all enemies that chase/patrol/aim/etc). The helper hierarchy will have most of the actual features, and is pretty undone at this point.
	//____________________
	//|   abs enemy		  |														________________
	//--------------------|/dependency/_________________________________________| abstract fact |
	//physical properties |														|_______________|______its children are the concrete factories that exist only to put enemies together
	//death/damage props  |														|has props for  |
	//--------------------|                                                     |creation		|
	//^																			-----------------
	//|
	//|
	//--------------------|
	//   concreteEnemy	  |
	//--------------------| 
	//contains some fea.s |
	//of abs, others are  |
	//changed for ea. enmy|
	//--------------------|
	//^^solid tri^^
	//|
	//|//So over here we're goin to create an abs helper class that brain and the like can inherit from (that'll be our interface).
	//|
	//----------|
	//  brain   |//actually, this goes below helper class as it's a type of helper that also has states; It's still making requests, but it's always the first node in the sequence.
	//----------|												   ______________	
	//+requests |/empty diamond/-----------------------^solid tri^|  abs state	 |
	//-states   |												  |--------------|^empty tri^^ -----------------child states:  "patrol" "chase" and "rest" others may arrive...
	//----------|												  |state stuff   |
	//^empty tri^												  |______________|
	//|	
	//|
	//|
	//helper class (handles requests or sends to next helper [contains next helper] and such is how parts/features are added to enemy.
	//if planning on coding to this interface, you may wish to watch a video on Chain of Responsibility.

	//ex: the legs class will handle jumping, and call a request down the line with "jumpAnimation" as the parameter. Your job is to create the necessary animation in a class
	//that's also a helper, but with the condition of doing the animation when it receives ^^^^ and passing it along otherwise (if it's a dif string).
	//Another possibility is that we want the animation to change depending on the state. A change in state will be something that sends requests down the line as well.
	//(this isn't exactly COR, as every helper will have the ability to send their requests through a public method in Brain, that will go down the line to all helpers.
	//This way we don't have to worry about the order we place the helpers in; any brand new requests, regardless of origin, will be sent to all helpers.
	//If you can think of a better way to chuck your visuals into this hierarchy, that's fine. Just please run it by me first. This is my baby.


//some other general notes about state classes

//patrol(name)
//setBounds(done when starting patrol if not already set by dev)
//check4Player(every cycle)
//walkToEdge(every cycle)

//chase
//begin exhaustion timer
//check4Player(every cycle)
//walkToEdge(or player, if not at edge yet)may need to redefine for smoothness
//look4next
//jump
//

//rest
//there will need to be an associated animation
//check4Player
//rest counter

//this is the basic line-up of jobs to be set by the factory classes for each enemy. I'm considering making them singleton classes, though, that are shared by all enemies
//in order to save space. For now, I'm only testing one or two at a time. So it doesn't matter. 			^them meaning both the features and repetitive states

//plan is to have different line-ups for different creatures in so far as state content. Jumpers will have different chase state than a UFO than a walker, etc.


//Lemme know if you want to see this really cool book on design patterns. It's like the programmers bible or something.



























using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUML : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
