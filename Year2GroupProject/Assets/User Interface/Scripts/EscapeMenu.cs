using UnityEngine;
using System.Collections;

public class EscapeMenu : MonoBehaviour {


	bool gamePaused = false;
	bool confirmationVisible = false;
	public GameObject escapeMenu;
	public GameObject confirmationMenu;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			gamePaused = !gamePaused;
		}

		if (gamePaused == true){
			Time.timeScale = 0;
			Cursor.visible = true;
			escapeMenu.SetActive(true);
			try{
				GameObject.FindGameObjectWithTag("Player").GetComponent<InteriorPlayerController>().enabled = false;
			} catch {
				GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ExteriorPlayerController>().enabled = false;
			}
		} else if (gamePaused == false){
			Time.timeScale = 1;
			escapeMenu.SetActive(false);
			try{
				GameObject.FindGameObjectWithTag("Player").GetComponent<InteriorPlayerController>().enabled = true;
			} catch {
				GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ExteriorPlayerController>().enabled = true;
			}
		}

		if (confirmationVisible == true) {
			confirmationMenu.SetActive (true);
		} else if (confirmationVisible == false) {
			confirmationMenu.SetActive (false);
		}
	}

	public void setPause(bool value){
		gamePaused = value;
	}

	public void setConfirmMenu(bool value){
		confirmationVisible = value;
	}		
}
