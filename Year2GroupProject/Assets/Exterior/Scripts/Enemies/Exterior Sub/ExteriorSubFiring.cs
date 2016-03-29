using UnityEngine;
using System.Collections;

public class ExteriorSubFiring : MonoBehaviour {

	enum state{
		approach,
		attack,
		death
	}
	
	public void setState(int value){
		currentState = (state)value;
		updateFiringState ();
	}
	
	state currentState;
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	int biteCounter;
	int biteDamage = 10;
	GameObject target;
	Animator animator;

	void Start(){
		//TEMP
		target = GameObject.FindGameObjectWithTag("Player");
		animator = GetComponent<Animator> ();
	}

	void updateFiringState(){
		if (currentState == state.approach) {
			animator.SetBool ("attack", false);
			try{
				CancelInvoke ("biteAttack");
			} 
			catch{
				
			}
		} else if (currentState == state.attack) {
			animator.SetBool ("attack", true);
			InvokeRepeating ("biteAttack", 3.0f, 1.0f);
			try{

			}
			catch{
				
			}
		}
	}

	void biteAttack(){
		if (biteCounter == 3) {
			damagePlayer(biteDamage);
			biteCounter = 0;
		}
		biteCounter++;
	}

	void damagePlayer(int damage){
		target.gameObject.GetComponent<PlayerHealth> ().dealDamage (damage);
	}
}
