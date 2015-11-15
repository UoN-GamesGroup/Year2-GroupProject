using UnityEngine;
using System.Collections;

public class tempenemy : MonoBehaviour {

	GameObject target;
	Rigidbody rigidbody;
	
	float rangeOfTarget;
	float holdRange;


	void Start () {
		int speed = 200;

		rigidbody = GetComponent<Rigidbody>();
		target = GameObject.Find ("Turret");

		transform.LookAt (target.transform.position);
		rigidbody.AddForce(transform.forward * speed);
		holdRange = 10;
	}

	void FixedUpdate () {
		rangeOfTarget = Vector3.Distance (transform.position, target.transform.position);
		if (rangeOfTarget <= holdRange) {
			rigidbody.velocity = Vector3.zero;
		}
	}
}
