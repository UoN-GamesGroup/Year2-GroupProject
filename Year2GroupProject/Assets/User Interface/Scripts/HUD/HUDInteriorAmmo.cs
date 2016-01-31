using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDInteriorAmmo : MonoBehaviour {

	Color colour_original = new Color(229f, 229f, 229f, 255f);
	Color colour_change = new Color(1f, 0f, 0f, 1f);
	public Text currentAmmo;
	public Text magSize;
	bool Reloading = false;

	void Awake () {
	
	}

	void Update () {
		currentAmmo.text = InteriorPlayerController.CurrentMag.ToString();
		magSize.text = InteriorPlayerController.MagSize.ToString();
	}

	public void bulletFired(){
		currentAmmo.color = colour_change;
		Invoke ("resetColour", 0.1f);
	}

	void resetColour(){
		currentAmmo.color = colour_original;
	}
}
