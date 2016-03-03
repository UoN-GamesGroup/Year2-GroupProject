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

	ExteriorMainMovement movementController;
	state currentState;
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	int acidDamage = 10;
	GameObject target;

	void Awake () {
		movementController = this.GetComponent<ExteriorMainMovement>();
		//TEMP
		target = GameObject.FindGameObjectWithTag("Player");
	}

	public void startStraithFiring(){
		Debug.Log ("Acid Activated");
		InvokeRepeating ("damagePlayerAcid", 0f, 0.5f);
		Invoke ("stopStraithFiringAcid", 3f);
	}

	void stopStraithFiring(){
		CancelInvoke ("damagePlayerAcid");
		movementController.finishedStraithFiring ();
	}

	void damagePlayerAcid(){
		target.gameObject.GetComponent<PlayerHealth> ().dealDamage (acidDamage);
	}
}
