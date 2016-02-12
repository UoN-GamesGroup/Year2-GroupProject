using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDExteriorAmmo : MonoBehaviour {

	Color colour_original = new Color(1f, 1f, 1f, 1f);
	Color colour_change = new Color(1f, 0f, 0f, 1f);
	public RawImage[] ammosymbols = new RawImage[11];
	public GameObject txt_Reloading;
	//Will Link these variables later
	bool reloading = false;
	int currentMagazine;

	public void bulletFired(){
		foreach (RawImage ammoSybmol in ammosymbols) {
			ammoSybmol.color = colour_change;
		}
		Invoke ("resetColour", 0.1f);
	}	

	void resetColour(){
		foreach (RawImage ammoSybmol in ammosymbols) {
			ammoSybmol.color = colour_original;
		}
	}

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		txt_Reloading.SetActive(reloading);

		currentMagazine = reloading ? 0 : ExteriorPlayerController.CurrentMag;
			
		for (int i = 0; i < ExteriorPlayerController.MagSize; i++) {
			if (i >= currentMagazine){
				ammosymbols[i].enabled = false;
			} else {
				ammosymbols[i].enabled = true;
			}
		}
	}

	public void setReloading(bool value){
		reloading = value;
	}
}
