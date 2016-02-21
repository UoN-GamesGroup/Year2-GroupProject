using UnityEngine;
using System.Collections;

public class InteriorTerminal : MonoBehaviour {

	float TimeRemaining = 30.0f;
	public bool Active = false;
	int Health = 100;

	void Start(){
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer> ();
		Color color = renderer.material.color;
		color.a = 0.4f;
		renderer.material.color = color;
	}

	public void setActive(bool value){
		Active = value;
		if (Active == true) {
			Debug.Log ("DEFEND OBJECTIVE ACTIVE!");
			InvokeRepeating ("countdown", 0.5f, 0.5f);
		} else {
			TimeRemaining = 30;
			int Health = 100;
		}
	}

	public bool getActive(){
		return Active;
	}

	void countdown(){
		TimeRemaining = TimeRemaining - 0.5f; 
		if (TimeRemaining <= 0.0f) {
			CancelInvoke ("coutdown");
			Debug.Log ("Terminal Defended");
			Active = false;
		}
	}

	void Update(){
		if (Active) {
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			if (Health <= 0) {
				CancelInvoke ("coutdown");
				Debug.Log ("Game ENDED");
			}
		} else {
			this.gameObject.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	void takeHealth(int value){
		Health -= value;
	}
}
