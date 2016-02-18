using UnityEngine;
using System.Collections;

public class InteriorMainMovement : MonoBehaviour {

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
	public float movementSpeed = 0.2f;
    int huntMovementCount;


	void Start()
	{
		target = GameObject.Find ("Player").transform;
		agent = GetComponent<NavMeshAgent>();
	}

	void Update(){
		agent.destination = target.position;
	}


	void huntMovement(){
        if (huntMovementCount == 3){
			agent.speed = 0;
		} else {
			agent.speed = movementSpeed;
    	}

		huntMovementCount++;
		if (huntMovementCount == 4) {
			huntMovementCount = 0;
		}
	}

	void attackMovement(){
		agent.speed = 0;
		//Debug.Log ("STOP");
    }

	void stateChanged(){
		try{
			CancelInvoke ("huntMovement");
		} 
		catch{

		}
		if (currentState == state.hunt) {
			InvokeRepeating("huntMovement", 0.0f, 1.0f);
		} else if (currentState == state.attack) {
			attackMovement();
		}
	}  
}