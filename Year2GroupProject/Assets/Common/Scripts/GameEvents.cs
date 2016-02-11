using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameEvents : MonoBehaviour {
	public GameObject endGameOverlay;

	public void gameOver(){
		endGameOverlay.SetActive (true);
	}
}
