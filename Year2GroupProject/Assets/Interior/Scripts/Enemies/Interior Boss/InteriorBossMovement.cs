using UnityEngine;
using System.Collections;

public class InteriorBossMovement : MonoBehaviour {

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
	public float movementSpeed = 0.1f;


	void Start()
	{
		target = GameObject.Find ("Player").transform;
		agent = GetComponent<NavMeshAgent>();

	}

	void Update(){
		agent.destination = target.position;
	}


	void huntMovement(){
		//Move To Target (set Speed to Movement Speed)
		agent.speed = 5;
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