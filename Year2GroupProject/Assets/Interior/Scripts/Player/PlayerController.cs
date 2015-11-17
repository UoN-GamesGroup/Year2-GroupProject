using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float LookSmoothDamp = 0.1f;
	public float LookSensitivity = 5;
	public float MovementSpeed = 5f;

	float XRotation, YRotation;
	float CurrentXRotation, CurrentYRotation; 
	float XRotationV = 0.0f, YRotationV = 0.0f; 

	public GameObject BulletEmitter;
	public GameObject Bullet;
	public GameObject PlayerCamera;

	public int MagSize = 12;
	int CurrentMag;
	float FireRate = 0.5f;
	float NextShot = 0.0f;
	int ReloadSpeed = 5;
	int ReloadCountdown;
	bool Reloading = false;

	void Start(){
		CurrentMag = MagSize;
		InvokeRepeating("reload", 0.0f, 1.0f);
	}

	void FixedUpdate () {

		checkCamera();

		/****Player Controls****/
		//MoveForward
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

		//Reload
		if (Input.GetKey(KeyCode.R) && CurrentMag < MagSize){
			ReloadCountdown = ReloadSpeed;
			Reloading = true;
		}
		//Fire
		if (Input.GetKey(KeyCode.Mouse0) && Time.time > NextShot && CurrentMag > 0) {
			NextShot = Time.time + FireRate;
			CurrentMag--;
			Debug.Log(CurrentMag);
			fire ();
		}
	}

	void fire(){
		Instantiate(Bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation);
	}

	void reload(){
		ReloadCountdown--;
		if (Reloading == true && ReloadCountdown <= 0){
			CurrentMag = MagSize;
			Reloading = false;
			Debug.Log ("Weapon Reload. Current Ammo: " + CurrentMag);
		}
	}

	
	void checkCamera(){
		YRotation += Input.GetAxis("Mouse X") * LookSensitivity; 
		XRotation -= Input.GetAxis("Mouse Y") * LookSensitivity; 
		
		XRotation = Mathf.Clamp(XRotation, -90, 90); 
		
		CurrentXRotation = Mathf.SmoothDamp(CurrentXRotation, XRotation, ref XRotationV, LookSmoothDamp); 
		CurrentYRotation = Mathf.SmoothDamp(CurrentYRotation, YRotation, ref YRotationV, LookSmoothDamp); 
		
		transform.rotation = Quaternion.Euler(0, CurrentYRotation, 0); 
		PlayerCamera.transform.rotation = Quaternion.Euler(CurrentXRotation, CurrentYRotation, 0);
	}
}
