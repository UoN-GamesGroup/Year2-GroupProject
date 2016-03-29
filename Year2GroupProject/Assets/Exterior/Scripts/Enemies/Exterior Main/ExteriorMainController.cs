using UnityEngine;
using System.Collections;

public class ExteriorMainController : MonoBehaviour {
	
	enum state{
		approach,
		straith,
		death
	}

	int Score = 20;
	int Health = 100;

	Animator animator;
	ExteriorMainMovement movementController;
	ExteriorMainFiring firingController;
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	state currentState;
	float targetRange;
	float orbitRange = 30;
	
	void Start(){
		animator = GetComponent<Animator> ();
		movementController = this.GetComponent<ExteriorMainMovement>();
		firingController = this.GetComponent<ExteriorMainFiring>();
		changeState(state.approach);
	}
	
	void Update(){
		if (Health <= 0) {
			if (currentState != state.death) {
				changeState (state.death);
				animator.SetBool ("Death", true);
				ScoreManager.Score += Score;
				ScoreManager.Kills++;
			}
			Invoke ("die", 2.0f);
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
		animator.SetBool ("hurt", true);
		animator.SetBool ("hurt", false);
	}

	void die(){
		Destroy(this.gameObject);
	}
}