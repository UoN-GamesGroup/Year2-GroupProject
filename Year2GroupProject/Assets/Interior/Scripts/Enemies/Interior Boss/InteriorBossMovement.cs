using UnityEngine;
using System.Collections;

public class InteriorBossMovement : MonoBehaviour {

	public void setState(int value){
		currentState = (state)value;
		try{
			CancelInvoke("huntMovement");
		} catch {

		}
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
		agent.Resume ();
		animator.SetBool ("Walk", true);
		Debug.Log ("HUNT MOVE");
	}

	void attackMovement(){
		agent.Stop ();
		animator.SetBool ("Walk", false);
		Debug.Log ("ATTACK MOVE");
	}

	void stateChanged(){
		if (currentState == state.hunt) {
			InvokeRepeating ("huntMovement", 0.0f, 1.0f);
		} else if (currentState == state.attack) {
			attackMovement ();
		} else if (currentState == state.death) {
			agent.Stop ();
			animator.SetBool ("Walk", false);
		}
	}  
}