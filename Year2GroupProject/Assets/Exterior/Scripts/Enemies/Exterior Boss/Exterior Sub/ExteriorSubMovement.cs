using UnityEngine;
using System.Collections;

public class ExteriorSubMovement : MonoBehaviour {
	
	public void setState(int value){
		currentState = (state)value;
	}
	
	enum state{
		approach,
		attack
	}
	
	state currentState;
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	float movementSpeed = 0.2f;
	
	
	void Start(){
		//Generate MovementSpeed
		//Get TargetPosition
	}
	
	void FixedUpdate(){
		if (currentState == state.approach) {
			approachMovement ();
		} else if (currentState == state.attack) {
			attackMovement();
		}
	}
	
	void approachMovement(){
		transform.LookAt (targetPosition);
		transform.Translate (0, 0, movementSpeed);
	}
	
	void attackMovement(){

	}
	
}
