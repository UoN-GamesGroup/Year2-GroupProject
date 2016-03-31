using UnityEngine;
using System.Collections;

public class ExteriorMainFiring : MonoBehaviour {

	enum state{
		approach,
		straith,
		death
	}
	
	public void setState(int value){
		currentState = (state)value;
	}


	public GameObject acidEmitter;
	ParticleEmitter emitter;

	ExteriorMainMovement movementController;
	state currentState;
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	int acidDamage = 10;
	GameObject target;
	Animator animator;

	void Awake () {
		movementController = this.GetComponent<ExteriorMainMovement>();
		target = GameObject.FindGameObjectWithTag("Player");

		emitter = acidEmitter.GetComponent<ParticleEmitter> ();
		animator = GetComponent<Animator> ();
	}

	public void startStraithFiring(){
		animator.SetBool ("attack", true);
		Debug.Log ("Acid Activated");
		emitter.emit = true;
		InvokeRepeating ("damagePlayerAcid", 0f, 0.5f);
		Invoke ("stopStraithFiringAcid", 3f);
	}

	void stopStraithFiring(){
		animator.SetBool ("attack", false);
		emitter.emit = false;
		CancelInvoke ("damagePlayerAcid");
		movementController.finishedStraithFiring ();
	}

	void damagePlayerAcid(){
		target.gameObject.GetComponent<PlayerHealth> ().dealDamage (acidDamage);
	}
}
