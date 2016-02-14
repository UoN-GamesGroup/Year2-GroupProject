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
    public float distance = 0.0f;
    public float targetRange = 3.0f;
    public GameObject Player;

    //INITIALIZE VARIABLES HERE

    void Start(){
		movementController = this.GetComponent<InteriorSubMovement>();
		firingController = this.GetComponent<InteriorSubFiring>();
        player = GameObject.FindGameObjectsWithTag("Player");
        changeState(state.hunt);
	}

	void Update(){
        //Checks health
        Vector3 targetPosition = player.gameObject.transform;
        targetRange = Vector3.Distance(transform.position, targetPosition);

        targetRange = Vector3.Distance(transform.position, targetPosition);
        if (targetRange >= distance)
        {
            if (currentState != state.hunt)
            {
                changeState(state.hunt);
            }
        }
        else {
            if (currentState != state.attack)
            {
                changeState(state.attack);
            }

            if (Health < 0) {
			ScoreManager.Score += Score;
			Destroy(this.gameObject);
		}

		//INSERT CHECKS TO DETERMINE STATE
		/*
		targetRange = Vector3.Distance (transform.position, targetPosition);
		if (targetRange >= orbitRange) {
			if (currentState != state.approach){
				changeState(state.approach);
			}
		} else {
			if (currentState != state.orbit){
				changeState(state.orbit);
			}
		}
		*/
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