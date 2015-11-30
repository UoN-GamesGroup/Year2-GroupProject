using UnityEngine;
using System.Collections;

public class DevMovement : MonoBehaviour {

	public float MovementSpeed = 5f;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)){
			transform.localPosition += transform.forward * MovementSpeed * Time.deltaTime;  
		}
		//MoveLeft
		if (Input.GetKey(KeyCode.A)){
			transform.localPosition -= transform.right * MovementSpeed * Time.deltaTime;  
		}
		//MoveBack
		if (Input.GetKey(KeyCode.S)){
			transform.localPosition -= transform.forward * MovementSpeed * Time.deltaTime;  
		}
		//MoveRight
		if (Input.GetKey(KeyCode.D)){
			transform.localPosition += transform.right * MovementSpeed * Time.deltaTime;  
		}
	}
}
