using UnityEngine;
using System.Collections;

public class ExteriorBossMovement : MonoBehaviour {

	public void setState(int value){
		currentState = (state)value;
		Debug.Log ("Firing State Set " + currentState);
	}

	enum state{
		approach,
		orbit
	}

	state currentState;
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	float movementSpeed = 0.05f;


	void Start(){
		//Generate MovementSpeed
		//Get TargetPosition
	}
	
	void FixedUpdate(){
		if (currentState == state.approach) {
			approachMovement ();
		} else if (currentState == state.orbit) {
			orbitMovement();
		}
	}

	void approachMovement(){
		transform.LookAt (targetPosition);
		transform.Translate (0, 0, movementSpeed);
	}

	void orbitMovement(){
		transform.LookAt (targetPosition);
		transform.Translate (movementSpeed, 0, 0);
	}

}
