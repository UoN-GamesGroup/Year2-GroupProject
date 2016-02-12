using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDHealth : MonoBehaviour {

	PlayerHealth playerHealth;
	public Image healthBar;

	int initialHealth;
	int currentHealth;
	float percentageHealth;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");;
		playerHealth = player.GetComponent<PlayerHealth> ();
		initialHealth = playerHealth.getPlayerHealth ();
	}

	void OnGUI () {
		currentHealth = playerHealth.getPlayerHealth ();
		percentageHealth = currentHealth / initialHealth; 
		healthBar.fillAmount = percentageHealth;	
	}

	public void playerHitEffect(){

	}
}
