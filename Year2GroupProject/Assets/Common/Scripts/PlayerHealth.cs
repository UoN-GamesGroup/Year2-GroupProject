using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	int Health = 1000;

	public void dealDamage(int value){
		Health -= value;
	}

	public int getPlayerHealth(){
		return Health;
	}

	void Update(){
		Debug.Log (Health);

		if (Health < 0) {
			//Game Over Circumstance
			Destroy (this.gameObject);
		}
	}
}
