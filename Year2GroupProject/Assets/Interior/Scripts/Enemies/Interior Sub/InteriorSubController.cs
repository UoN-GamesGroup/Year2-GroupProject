using UnityEngine;
using System.Collections;

public class InteriorSubController : MonoBehaviour {

	enum state{
		hunt,
		attack,
		death
	}

	int Score = 50;
	int Health = 100;

	Animator animator;
	InteriorSubMovement movementController;
	InteriorSubFiring firingController;
	state currentState;
	Transform player;

	float distance;
	public float targetRange = 0.2f;

	//INITIALIZE VARIABLES HERE

	void Start(){
		movementController = this.GetComponent<InteriorSubMovement>();
		firingController = this.GetComponent<InteriorSubFiring>();
		animator = GetComponent<Animator> ();
		player = GameObject.Find ("Player").transform;
		changeState(state.hunt);
	}

	void Update(){
		distance = Vector3.Distance(transform.position, player.position);
		if (Health <= 0) {
			if (currentState != state.death){
				changeState(state.death);
				animator.SetBool ("Death", true);
				ScoreManager.Score += Score;
				Invoke ("die", 3.0f);
			}
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