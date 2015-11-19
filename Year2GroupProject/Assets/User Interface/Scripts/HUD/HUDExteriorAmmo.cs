using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDExteriorAmmo : MonoBehaviour {
	
	//Will Link these variables later
	int MagSize = 8;
	int CurrentMag = 5;
	bool Reloading = false;

	//Same as Interior, but ammo is shown with bullet icons. Show the number of bullets in current mag in icons
	
	
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Update both text objects to show variables
		//When reloading equals true show reloaing text instead of mag contents
	}
}
