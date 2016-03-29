using UnityEngine;
using System.Collections;

public class ExteriorBossFiring : MonoBehaviour {
	
	enum state{
		approach,
		orbit,
		death
	}

	public void setState(int value){
		currentState = (state)value;
		updateFiringState ();
	}

	state currentState;
	Vector3 targetPosition = new Vector3 (0, 0, 0);
	bool fireSide = true;
	int missileCounter = 0;
	int laserCountdown;
	bool laserActive = false;
	bool laserFiring = false;
	int laserDamage = 20;
	Animator animator;
	GameObject target;

	public GameObject laser;
	public Transform startPoint;
	LineRenderer laserLine;

	public GameObject missileEmitterLeft;
	public GameObject missileEmitterRight;
	public GameObject missile;

	void Start(){
		animator = GetComponent<Animator> ();
		target = GameObject.FindGameObjectWithTag("Player");

		laserLine = laser.GetComponent<LineRenderer> ();
		laserLine.SetWidth (0.1f, 0.1f);
		//Generate MovementSpeed
		//Get TargetPosition
	}

	void Update(){
		laserLine.SetPosition (0, startPoint.position);
		laserLine.SetPosition (1, targetPosition);

		//Turn On/Off LaserLine
		if (laserActive == true) {
			laserLine.enabled = true;
		} else {
			laserLine.enabled = false;
		}
	}

	void updateFiringState(){
		if (currentState == state.approach) {
			InvokeRepeating ("fireMissiles", 1.0f, 1.0f);
			try{
				CancelInvoke ("fireLaser");
			} 
			catch{

			}
		} else if (currentState == state.orbit) {
			InvokeRepeating ("fireLaser", 2.0f, 0.5f);
			try{
				CancelInvoke ("fireMissiles");
			}
			catch{

			}
		}
	}

	void fireMissiles(){

		if (missileCounter == 1) {
			Instantiate(missile, missileEmitterLeft.transform.position, missileEmitterLeft.transform.rotation);
		} else if (missileCounter == 2){
			Instantiate(missile, missileEmitterRight.transform.position, missileEmitterRight.transform.rotation);
		} else if (missileCounter == 3){
			missileCounter = 0;
		}

		missileCounter++;
	}

	void fireLaser(){

		switch (laserCountdown) {
		case 1:
			laserActive = true;
			break;
		case 5:
			laserFiring = true;
			damagePlayer(laserDamage);
			break;
		case 6:
			laserFiring = false;
			break;
		case 7:
			laserActive = false;
			break;
		case 10:
			laserCountdown = 0;
			break;		
		default: 
			break;
		}

		if (laserActive) {
			laser.transform.LookAt (targetPosition);
		}
		laserCountdown++;
	}

	void damagePlayer(int damage){
		target.gameObject.GetComponent<PlayerHealth> ().dealDamage (damage);
	}
}
