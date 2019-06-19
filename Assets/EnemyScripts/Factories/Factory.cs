using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RickObject", menuName = "Walker")]
public class Factory : ScriptableObject //This is just going to be a concrete walking enemy factory. I'm not seeing a point to an abstract factory as of yet...
{
	
	private Brain brain;
	private Chase chase;
	private Patrol patrol;
	private walk walkHelp;

		
		
		
		void Awake()
		{
		
		}
	
    // Start is called before the first frame update
    void Start()
    {
       
    }
}
//solution: factory class puts all things together but also uses the unitychan method of adding rigidbody2d and collider so that they can be called by the brain class and all
//its helpers. we have to make them public of course. Then we use the menu option to make them appear easily and boom we're gucci.