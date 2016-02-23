using UnityEngine;
using System.Collections;

public class InteriorMainMovement : MonoBehaviour {

	public void setState(int value){
		currentState = (state)value;
		stateChanged ();
	}

	enum state{
		hunt,
		attack,
		death
	}

	state currentState;
	Transform target; //Current Leave Public (Will be Passed Location By Another System later)
	NavMeshAgent agent;
	public float movementSpeed = 0.01f;
    int huntMovementCount;
	Vector3 destination;
	Animator animator;


	void Start()
	{
		animator = GetComponent<Animator> ();
		target = GameObject.Find ("Player").transform;
		agent = GetComponent<NavMeshAgent>();
		destination = agent.destination;
	}

	void Update(){
		if (Vector3.Distance (destination, target.position) > 1.0f) {
			destination = target.position;
			agent.destination = destination;
		}
	}


	void huntMovement(){
		animator.SetBool ("Walk", true);
        if (huntMovementCount == 3){
			agent.speed = 0;
			animator.SetBool ("Walk", false);
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
		animator.SetBool ("Walk", false);
    }

	void stateChanged(){
		if (currentState == state.hunt) {
			InvokeRepeating ("huntMovement", 0.0f, 1.0f);
			Debug.Log ("Do I GET CALLED!");
		} else if (currentState == state.attack) {
			attackMovement ();
		} else if (currentState == state.death) {
			agent.speed = 0;
			animator.SetBool ("Walk", false);
		}
	}  
}