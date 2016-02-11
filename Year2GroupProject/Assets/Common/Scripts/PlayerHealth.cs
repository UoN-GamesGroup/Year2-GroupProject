using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	GameEvents gameEvents;
	int Health = 1000;

	void Start(){
		GameObject gm = GameObject.Find ("GameManager");
		gameEvents = gm.gameObject.GetComponent<GameEvents> ();
	}

	public void dealDamage(int value){
		Health -= value;
	}

	public int getPlayerHealth(){
		return Health;
	}

	void Update(){
		Debug.Log (Health);

		if (Health <= 0) {
			gameEvents.gameOver ();
			Destroy (this.gameObject);
		}
	}
}
