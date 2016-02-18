using UnityEngine;
using System.Collections;

public class InteriorSubController : MonoBehaviour {

	enum state{
		hunt,
		attack
	}

	int Score = 50;
	int Health = 100;

	InteriorSubMovement movementController;
	InteriorSubFiring firingController;
	state currentState;
	GameObject player;

	float distance;
	public float targetRange = 0.2f;

	//INITIALIZE VARIABLES HERE

	void Start(){
		movementController = this.GetComponent<InteriorSubMovement>();
		firingController = this.GetComponent<InteriorSubFiring>();
		player = GameObject.FindGameObjectWithTag("Player");
		changeState(state.hunt);
	}

	void Update(){
		//Checks health
		if (Health <= 0) {
			ScoreManager.Score += Score;
			Destroy(this.gameObject);
		}

		distance = Vector3.Distance(transform.position, player.gameObject.transform.position);
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