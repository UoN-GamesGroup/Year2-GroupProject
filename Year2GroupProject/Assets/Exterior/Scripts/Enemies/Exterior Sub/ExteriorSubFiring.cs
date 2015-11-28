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
			//Attack
			biteCounter = 0;
		}
		biteCounter++;
	}
}
