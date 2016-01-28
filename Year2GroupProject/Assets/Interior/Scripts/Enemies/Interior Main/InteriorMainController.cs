﻿using UnityEngine;
using System.Collections;

public class InteriorMainController : MonoBehaviour {

	enum state{
		hunt,
		attack
	}

	int Score = 50;
	int Health = 100;

	InteriorMainMovement movementController;
	InteriorMainFiring firingController;
	state currentState;

	//INITIALIZE VARIABLES HERE

	void Start(){
		movementController = this.GetComponent<InteriorMainMovement>();
		firingController = this.GetComponent<InteriorMainFiring>();
		changeState(state.hunt);
	}

	void Update(){
		//Checks health
		if (Health < 0) {
			ScoreManager.Score += Score;
			Destroy(this.gameObject);
		}

		//INSERT CHECKS TO DETERMINE STATE
		/*
		targetRange = Vector3.Distance (transform.position, targetPosition);
		if (targetRange >= orbitRange) {
			if (currentState != state.approach){
				changeState(state.approach);
			}
		} else {
			if (currentState != state.orbit){
				changeState(state.orbit);
			}
		}
		*/
	}

	void changeState(state value){
		currentState = value;
		movementController.setState ((int)currentState);
		firingController.setState ((int)currentState);
	}

	public void dealDamage(int value){
		Health -= value;
	}
}