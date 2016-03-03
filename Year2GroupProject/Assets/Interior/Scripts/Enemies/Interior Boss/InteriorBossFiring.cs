using UnityEngine;
using System.Collections;

public class InteriorBossFiring : MonoBehaviour {

	enum state{
		hunt,
		attack,
		death
	}

	public void setState(int value){
		currentState = (state)value;
		updateFiringState ();
	}

	state currentState;
	GameObject target;
	Vector3 targetPosition;
	int damage = 80;
	Animator animator;

	void Start(){
		animator = this.GetComponent<Animator> ();
		target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update(){
		targetPosition = target.transform.position;
	}

	void updateFiringState(){
		if (currentState == state.hunt) {
			animator.SetBool ("Attack", false);
			try {
				CancelInvoke ("attackState");
			} catch {

			}
		} else if (currentState == state.attack) {
			animator.SetBool ("Attack", true);
			InvokeRepeating ("attackState", 0.0f, 3.5f); // Change these values if needed
		} else if (currentState == state.death) {
			animator.SetBool ("Attack", false);
			try{
				CancelInvoke ("attackState");
			} 
			catch{

			}
		}
	}

	void attackState(){
		target.gameObject.GetComponent<PlayerHealth> ().dealDamage (damage);
	}
}