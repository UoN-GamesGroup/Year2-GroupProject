using UnityEngine;
using System.Collections;

public class InteriorSubMovement : MonoBehaviour {

	public void setState(int value){
		currentState = (state)value;
		stateChanged ();
	}

	enum state{
		hunt,
		attack
	}

	state currentState;
	Transform target; //Current Leave Public (Will be Passed Location By Another System later)
	NavMeshAgent agent;
	public float movementSpeed = 0.01f;
    int huntMovementCount;
	Vector3 destination;
        
	void Start()
	{
		target = GameObject.Find ("Player").transform;
		agent = this.GetComponent<NavMeshAgent>();
		destination = agent.destination;
	}

	void Update(){
		if (Vector3.Distance (destination, target.position) > 1.0f) {
			destination = target.position;
			agent.destination = destination;
		}
	}


	void huntMovement(){
		//Move To Target (set Speed to Movement Speed)
		agent.speed = 5.0f;
	}

	void attackMovement(){
		agent.speed = 0;
	}

	void stateChanged(){
		if (currentState == state.hunt) {
			huntMovement ();
		} else if (currentState == state.attack) {
			attackMovement();
		}
	}  
}