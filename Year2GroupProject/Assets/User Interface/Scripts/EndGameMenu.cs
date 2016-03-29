using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameMenu : MonoBehaviour {

	public Text txtWaves;
	public Text txtScore;
	public Text txtKills;

	void Start () {
		txtWaves.text = "Wave: " + PlayerPrefs.GetInt ("Wave_LastGame").ToString().PadLeft(2, '0');
		txtScore.text = "Score: " + PlayerPrefs.GetInt ("Score_LastGame").ToString().PadLeft(6, '0');
		txtKills.text = "Kills: " + PlayerPrefs.GetInt ("Kills_LastGame").ToString().PadLeft(6, '0');
	}
}
