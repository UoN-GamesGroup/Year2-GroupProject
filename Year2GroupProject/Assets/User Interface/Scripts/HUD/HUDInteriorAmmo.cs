using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDInteriorAmmo : MonoBehaviour {

	//Will Link these variables later
	int MagSize = 12;
	int CurrentMag = 11;
	bool Reloading = false;

	//Initialize three text objects. Two mag siz and current mag and another for reloading text

	//ADDITIONAL - Make a method that alters the current mag text when run.
	//			 - Changes colour for a few seconds
	//			 - Englarges Slightly
	// 			 Just Signify Ammo Change. Even if when mag is low, to notify player low mag.


	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Update both text objects to show variables
		//When reloading equals true show reloaing text instead of mag contents
	}
}
