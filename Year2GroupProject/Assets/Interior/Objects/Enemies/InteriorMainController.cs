using UnityEngine;
using System.Collections;

public class InteriorMainController : MonoBehaviour {
	
	enum state{
		approach,
		straith
	}

	int Score = 20;
	int Health = 100;

	ExteriorMainMovement movementController;
	ExteriorMainFiring firingController;
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	state currentState;
	float targetRange;
	float orbitRange = 30;
	
	void Start(){
		movementController = this.GetComponent<ExteriorMainMovement>();
		firingController = this.GetComponent<ExteriorMainFiring>();
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
			if (currentState != state.straith){
				changeState(state.straith);
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