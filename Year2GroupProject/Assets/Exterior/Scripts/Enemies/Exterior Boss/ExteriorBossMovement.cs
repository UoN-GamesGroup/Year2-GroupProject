using UnityEngine;
using System.Collections;

public class ExteriorBossMovement : MonoBehaviour {

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
		orbit,
		death
	}

	state currentState;
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	float movementSpeed = 0.05f;
	Animator animator;


	void Start(){
		animator = GetComponent<Animator> ();
	}
	
	void FixedUpdate(){
		if (currentState == state.approach) {
			approachMovement ();
		} else if (currentState == state.orbit) {
			orbitMovement ();
		} else if (currentState == state.death) {
		}
	}

	void approachMovement(){
		transform.LookAt (targetPosition);
		transform.Translate (0, 0, movementSpeed);
	}

	void orbitMovement(){
		transform.LookAt (targetPosition);
		transform.Translate (movementSpeed, 0, 0);
	}
}
