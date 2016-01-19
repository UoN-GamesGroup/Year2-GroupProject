using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDExteriorAmmo : MonoBehaviour {

	Color colour_original = new Color(1f, 1f, 1f, 1f);
	Color colour_change = new Color(1f, 0f, 0f, 1f);
	public RawImage[] ammosymbols = new RawImage[11];
	//Will Link these variables later
	bool Reloading = false;

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
		for (int i = 0; i < ExteriorPlayerController.MagSize; i++) {
			if (i >= ExteriorPlayerController.CurrentMag){
				ammosymbols[i].enabled = false;
			} else {
				Debug.Log("called2");
				ammosymbols[i].enabled = true;
			}
		}
	}
}
