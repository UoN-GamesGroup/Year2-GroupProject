using UnityEngine;
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
	Transform player;

	float distance;
	public float targetRange = 2.0f;

	//INITIALIZE VARIABLES HERE

	void Start(){
		movementController = this.GetComponent<InteriorMainMovement>();
		firingController = this.GetComponent<InteriorMainFiring>();
		player = GameObject.Find ("Player").transform;
	}

	void Update(){
		//Checks health
		if (Health <= 0) {
			ScoreManager.Score += Score;
			Destroy(this.gameObject);
		}

		distance = Vector3.Distance(transform.position, player.position);
		if (targetRange <= distance) {
			if (currentState != state.hunt){
				changeState(state.hunt);
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