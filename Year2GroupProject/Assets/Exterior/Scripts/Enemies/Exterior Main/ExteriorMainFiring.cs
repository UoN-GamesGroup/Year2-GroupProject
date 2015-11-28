using UnityEngine;
using System.Collections;

public class ExteriorMainFiring : MonoBehaviour {

	enum state{
		approach,
		straith
	}
	
	public void setState(int value){
		currentState = (state)value;
	}

	public GameObject acidEmitter;
	ParticleSystem acidParticleSystem;

	ExteriorMainMovement movementController;
	state currentState;
	Vector3 targetPosition = new Vector3 (0, 0, 0);

	void Awake () {
		acidParticleSystem = acidEmitter.GetComponent<ParticleSystem>();
		movementController = this.GetComponent<ExteriorMainMovement>();
		acidParticleSystem.enableEmission = false;
	}

	public void startStraithFiring(){
		Debug.Log ("Acid Activated");
		acidParticleSystem.enableEmission = true;
		Invoke ("stopStraithFiring", 3f);
	}

	void stopStraithFiring(){
		acidParticleSystem.enableEmission = false;
		movementController.finishedStraithFiring ();
	}
}
