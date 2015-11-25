using UnityEngine;
using System.Collections;

public class ExteriorMainEnemyController : MonoBehaviour {
	
	enum state{
		approach,
		orbit
	}
	
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	state currentState;
	
	float movementSpeed = 0.2f;
	float verticleMovementSpeed;
	float orbitRange = 50;
	float orbitHeight = 20;
	float targetRange;
	
	void Start () {
		currentState = state.approach;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		targetRange = Vector3.Distance (transform.position, targetPosition);
		
		if (targetRange <= orbitRange) {
			currentState = state.orbit;
		} else {
			currentState = state.approach;
		}
		
		switch (currentState) {
		case state.approach:
			stateApproach ();
			break;
		case state.orbit:
			stateOrbit ();
			break;
		}
		
	}
	
	void stateApproach(){
		transform.LookAt (targetPosition);
		transform.Translate (0, 0, movementSpeed);
	}
	
	void stateOrbit(){
		transform.LookAt (targetPosition);
		transform.Translate (movementSpeed / 2, -verticleMovementSpeed, 0);
		
		if (transform.position.y > orbitHeight){
			verticleMovementSpeed = movementSpeed / 4; 
		}
		else {
			verticleMovementSpeed = 0;
		}
	}
}