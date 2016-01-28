using UnityEngine;
using System.Collections;

public class ExteriorSubFiring : MonoBehaviour {

	enum state{
		approach,
		attack
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

	void Start(){
		//TEMP
		target = GameObject.FindGameObjectWithTag("Player");
	}

	void updateFiringState(){
		if (currentState == state.approach) {
			try{
				CancelInvoke ("biteAttack");
			} 
			catch{
				
			}
		} else if (currentState == state.attack) {
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
