using UnityEngine;
using System.Collections;

public class ExteriorSubController : MonoBehaviour {
	
	enum state{
		approach,
		attack
	}

	int Score = 10;
	int Health = 10;

	ExteriorSubMovement movementController;
	ExteriorSubFiring firingController;
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	state currentState;
	float targetRange;
	float orbitRange = 15;
	
	void Start(){
		movementController = this.GetComponent<ExteriorSubMovement>();
		firingController = this.GetComponent<ExteriorSubFiring>();
		changeState(state.approach);
	}
	
	void Update(){
		if (Health < 0) {
			ScoreManager.Score += Score;
			Destroy(this.gameObject);
		}
		targetRange = Vector3.Distance (transform.position, targetPosition);
		if (targetRange >= orbitRange) {
			if (currentState != state.approach){
				changeState(state.approach);
			}
		} else {
			if (currentState != state.attack){
				changeState(state.attack);
			}
		}
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