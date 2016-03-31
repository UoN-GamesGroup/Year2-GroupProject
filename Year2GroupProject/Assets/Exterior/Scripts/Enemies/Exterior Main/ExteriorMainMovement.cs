using UnityEngine;
using System.Collections;

public class ExteriorMainMovement : MonoBehaviour {

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
		straith,
		death
	}

	ExteriorMainFiring firingController;
	state currentState;
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	float movementSpeed = 0.05f;
	float straithSpeed = 0.2f;
	int straithStage = 1;
	int straithMoveCounter;
	int meshRotation = 90;
	bool straithFiring = false;
	bool straithMoving = true;
	bool straithDirection = true;
	float straithMovementCountdown;
	Animator animator;
	public GameObject meshBody;

	void Start () { 
		animator = GetComponent<Animator> ();
		Vector3 targetPosition = new Vector3 (0, 0, 0);
		straithMovementCountdown = Random.Range (2, 8);
		firingController = this.GetComponent<ExteriorMainFiring>();
	}

	void FixedUpdate(){
		if (currentState == state.approach) {
			approachMovement ();
		} else if (currentState == state.straith){
			straithState();
			if (straithMoving == true){
				if ( straithMovementCountdown <= 0 )
				{
					straithStage = 2;
					straithMoving = false;
				} else {
					straithMove();
					straithMovementCountdown -= Time.deltaTime;
				}
			}
		}else if (currentState == state.death) {
		}
	}
	
	void approachMovement(){
		transform.LookAt (targetPosition);
		transform.Translate (0, 0, movementSpeed);
	}

	void straithState(){
		switch(straithStage){
			case 1:
				if(straithMoving == false){
					straithMoving = true;
				}
				break;
			case 2:
				faceEnemy();
				Debug.Log ("Stage 2Acticve");
				break;
			case 3:
			Debug.Log ("Stage 3Acticve");
				if(straithFiring == false){
				Debug.Log ("Sent to Firing");
					firingController.startStraithFiring();
					straithFiring = true;
				}
				break;
			case 4:
				faceForward();
				break;
			case 5:
				straithMovementCountdown = Random.Range (2, 20);
				straithDirection = !straithDirection;
				straithStage = 1;
				break;
		}
	}

	void straithMove(){
		transform.LookAt (targetPosition);
		if (straithDirection) {
			transform.Translate (straithSpeed, 0, 0);
		} else {
			transform.Translate (-straithSpeed, 0, 0);
		}
	}
	
	void faceEnemy(){
		straithStage = 3;
	}

	void faceForward(){
		straithStage = 5;
	}

	public void finishedStraithFiring(){
		straithStage = 4;
		straithFiring = false;
	}
}
