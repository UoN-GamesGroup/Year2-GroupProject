using UnityEngine;
using System.Collections;

public class InteriorMainMovement : MonoBehaviour {

	public void setState(int value){
		currentState = (state)value;
	}

	enum state{
		hunt,
		attack
	}

	state currentState;
	Transform target; //Current Leave Public (Will be Passed Location By Another System later)
	NavMeshAgent agent;
	public float movementSpeed = 2.0f;


	void Start()
	{
		target = GameObject.Find ("Player").transform;
		agent = GetComponent<NavMeshAgent>();
	}

	void FixedUpdate(){
		//Keep Updating Target Location
		agent.destination = target.position;

		//Check state set to and run appropriate method
		if (currentState == state.hunt) {
			huntMovement ();
		} else if (currentState == state.attack) {
			attackMovement();
		}
	}


	void huntMovement(){
		//Move To Target (set Speed to Movement Speed)
	}

	void attackMovement(){
		//Stop Movement (set Speed to 0)
	}
}