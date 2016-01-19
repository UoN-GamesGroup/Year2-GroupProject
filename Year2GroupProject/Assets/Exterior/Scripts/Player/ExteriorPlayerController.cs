using UnityEngine;
using System.Collections;

public class ExteriorPlayerController : MonoBehaviour {

	//Temporary Controls: Will Change to Assigned Keys Maps and Add Controller Support Late
	public GameObject Frame;
	public GameObject Bullet;
	public GameObject BulletEmitter;

	public float LookSmoothDamp = 0.1f;
	public float LookSensitivity = 2;
	public float MovementSpeed = 5f;

	public GameObject HUDAmmo;
	HUDExteriorAmmo HUDAmmoScript;

	public static int MagSize = 11;
	public static int CurrentMag;
	float FireRate = 0.5f;
	float NextShot = 0.0f;
	int ReloadSpeed = 5;
	int ReloadCountdown;
	bool Reloading = false;

	float XRotation, YRotation;
	float CurrentXRotation, CurrentYRotation; 
	float XRotationV = 0.0f, YRotationV = 0.0f;

	void Start(){
		HUDAmmoScript = HUDAmmo.gameObject.GetComponent<HUDExteriorAmmo> ();
		CurrentMag = MagSize;
		InvokeRepeating("reload", 0.0f, 1.0f);
	}
	
	void Update () {

		checkCamera ();

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
		HUDAmmoScript.bulletFired ();
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
		
		XRotation = Mathf.Clamp(XRotation, -90, 20); 
		
		CurrentXRotation = Mathf.SmoothDamp(CurrentXRotation, XRotation, ref XRotationV, LookSmoothDamp); 
		CurrentYRotation = Mathf.SmoothDamp(CurrentYRotation, YRotation, ref YRotationV, LookSmoothDamp); 
		
		Frame.transform.rotation = Quaternion.Euler(0, CurrentYRotation, 0); 
		transform.rotation = Quaternion.Euler(CurrentXRotation, CurrentYRotation, 0);
	}
}
