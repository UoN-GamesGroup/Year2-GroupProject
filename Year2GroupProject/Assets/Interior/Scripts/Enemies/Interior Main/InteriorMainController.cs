using UnityEngine;
using System.Collections;

public class InteriorMainController : MonoBehaviour {

	enum state{
		hunt,
		attack,
		death
	}

	int Score = 50;
	int Health = 100;

	Animator animator;
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
		animator = GetComponent<Animator> ();
		player = GameObject.Find ("Player").transform;
		changeState (state.hunt);
	}

	void Update(){
		//Checks health
		if (Health <= 0) {
			changeState (state.death);
			animator.SetBool ("Death", true);
			ScoreManager.Score += Score;
			Invoke ("Die", 3.0f);
		}

		distance = Vector3.Distance(transform.position, player.position);
		if (currentState == state.death) {

		} else if (targetRange <= distance) {
			if (currentState != state.hunt){
				changeState(state.hunt);
			}
		} else{
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

	void die (){
		Destroy (this.gameObject);
	}
}