using UnityEngine;
using System.Collections;

public class InteriorDoorController : MonoBehaviour {

	Animator animator;

	void Start(){
		animator = this.gameObject.GetComponent<Animator> ();
	}
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.CompareTag("Player")){
			animator.SetBool ("Activated", true);
		}
	}

	void OnTriggerExit(Collider collider){
		if (collider.gameObject.CompareTag("Player")){
			animator.SetBool ("Activated", false);
		}
	}
}
