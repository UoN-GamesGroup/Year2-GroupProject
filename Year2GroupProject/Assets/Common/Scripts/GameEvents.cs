using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameEvents : MonoBehaviour {
	public GameObject endGameOverlay;

	public void gameOver(){
		PlayerPrefs.SetInt("Wave_LastGame", WaveManager.wave);
		PlayerPrefs.SetInt("Score_LastGame", ScoreManager.Score);
		PlayerPrefs.SetInt("Kills_LastGame", ScoreManager.Kills);
		endGameOverlay.SetActive (true);
		Invoke ("EndGame", 3.0f);
	}

	void EndGame(){
		this.gameObject.GetComponent<ChangeScene> ().changeSceneTo ("EndGameMenu");
	}
}
