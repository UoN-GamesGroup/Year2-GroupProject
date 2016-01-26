using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDScores : MonoBehaviour {

	public Text TxtHighScore;
	public Text TxtScore;

	void OnGUI(){
		string score = ScoreManager.Score.ToString().PadLeft(6, '0');
		TxtScore.text = "SCORE: " + score;
	}
}
