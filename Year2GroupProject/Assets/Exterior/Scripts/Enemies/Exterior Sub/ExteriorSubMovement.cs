using UnityEngine;
using System.Collections;

public class ExteriorSubMovement : MonoBehaviour {
	
	public void setState(int value){
		currentState = (state)value;
		if (currentState != state.death) {
			animator.SetBool ("move", true);
		} else {
			animator.SetBool ("move", false);
		}
	}
	
	enum state{
		approach,
		attack,
		death
	}
	
	state currentState;
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	float movementSpeed = 0.2f;
	Animator animator;
	
	void Start(){
		animator = GetComponent<Animator> ();
	}
	
	void FixedUpdate(){
		if (currentState == state.approach) {
			approachMovement ();
		} else if (currentState == state.attack) {
			attackMovement();
		} else if (currentState == state.death) {
		}
	}
	
	void approachMovement(){
		transform.LookAt (targetPosition);
		transform.Translate (0, 0, movementSpeed);
	}
	
	void attackMovement(){

	}
	
}
