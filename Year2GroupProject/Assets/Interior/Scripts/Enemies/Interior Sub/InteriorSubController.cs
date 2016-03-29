﻿using UnityEngine;
using System.Collections;

public class InteriorSubController : MonoBehaviour {

	enum state{
		hunt,
		attack,
		death
	}

	int Score = 50;
	public int Health = 100;

	Animator animator;
	InteriorSubMovement movementController;
	InteriorSubFiring firingController;
	state currentState;
	Transform player;

	float distance;
	public float targetRange = 2.0f;

	//INITIALIZE VARIABLES HERE

	void Start(){
		movementController = this.GetComponent<InteriorSubMovement>();
		firingController = this.GetComponent<InteriorSubFiring>();
		animator = GetComponent<Animator> ();
		player = GameObject.Find ("Player").transform;
		changeState (state.hunt);
	}

	void Update(){
		distance = Vector3.Distance(transform.position, player.position);
		if (Health <= 0) {
			Debug.Log ("Calling Dead");
			if (currentState != state.death){
				changeState(state.death);
				animator.SetBool ("Death", true);
				ScoreManager.Score += Score;
				ScoreManager.Kills++;
				Invoke ("die", 4.0f);
			}
		} else if (targetRange <= distance) {
			Debug.Log ("Calling Hunt");
			if (currentState != state.hunt){
				changeState(state.hunt);
			}
		} else{
			Debug.Log ("Calling Attack");
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
		animator.SetBool ("Hurt", true);
		animator.SetBool ("Hurt", false);
	}

	void die (){
		Destroy (this.gameObject);
	}
}