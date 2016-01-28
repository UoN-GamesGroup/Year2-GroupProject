using UnityEngine;
using System.Collections;

public class InteriorBossFiring : MonoBehaviour {

	enum state{
		hunt,
		attack
	}

	public void setState(int value){
		currentState = (state)value;
		updateFiringState ();
	}

	state currentState;
	GameObject target;
	Vector3 targetPosition;

	void Start(){
		//TEMP
		target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update(){
		targetPosition = target.gameObject.transform.position;
	}

	void updateFiringState(){
		if (currentState == state.hunt) {
			InvokeRepeating ("huntState", 2.0f, 0.5f); // Change these values if needed
			try{
				CancelInvoke ("attackState");
			} 
			catch{

			}
		} else if (currentState == state.attack) {
			InvokeRepeating ("attackState", 2.0f, 0.5f); // Change these values if needed
			try{
				CancelInvoke ("huntState");
			}
			catch{

			}
		}
	}

	void huntState(){

	}

	void attackState(){

	}
}