using UnityEngine;
using System.Collections;

public class InteriorSubFiring : MonoBehaviour {

	enum state{
		hunt,
		attack,
		death
	}

	public void setState(int value){
		currentState = (state)value;
		updateFiringState ();
	}

	public GameObject Bullet;
	public GameObject BulletEmitter;
	GameObject target;

	Animator animator;

	Vector3 targetPosition;
	state currentState;

	int damage = 40;


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
			InvokeRepeating ("attackState", 2.0f, 1f); // Change these values if needed
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
		Instantiate(Bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation);
	}
}