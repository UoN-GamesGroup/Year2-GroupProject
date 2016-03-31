using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameMenu : MonoBehaviour {

	public Text txtWaves;
	public Text txtScore;
	public Text txtKills;

	string level;

	void Start () {
		txtWaves.text = "Wave: " + PlayerPrefs.GetInt ("Wave_LastGame").ToString().PadLeft(2, '0');
		txtScore.text = "Score: " + PlayerPrefs.GetInt ("Score_LastGame").ToString().PadLeft(6, '0');
		txtKills.text = "Kills: " + PlayerPrefs.GetInt ("Kills_LastGame").ToString().PadLeft(6, '0');

		level = PlayerPrefs.GetString ("Level_LastGame");

		if (level == "interior") {
			if (!PlayerPrefs.HasKey ("Stats_Interior_HighScore")) {
				PlayerPrefs.SetInt ("Stats_Interior_HighScore", 0);
			}
			if (!PlayerPrefs.HasKey ("Stats_Interior_Highest_Wave")) {
				PlayerPrefs.SetInt ("Stats_Interior_Highest_Wave", 0);
			}
			if (!PlayerPrefs.HasKey ("Stats_Interior_TotalKills")) {
				PlayerPrefs.SetInt ("Stats_Interior_TotalKills", 0);
			}


			PlayerPrefs.SetInt ("Stats_InteriorTotalKills", PlayerPrefs.GetInt("Kills_LastGame") + PlayerPrefs.GetInt("Stats_Interior_TotalKills"));

			if (PlayerPrefs.GetInt ("Stats_Interior_Highest_Wave") < PlayerPrefs.GetInt ("Wave_LastGame")) {
				PlayerPrefs.SetInt ("Stats_Interior_Highest_Wave", PlayerPrefs.GetInt("Wave_LastGame"));
			}

			if (PlayerPrefs.GetInt ("Stats_Interior_HighScore") < PlayerPrefs.GetInt ("Score_LastGame")) {
				PlayerPrefs.SetInt ("Stats_Interior_HighScore", PlayerPrefs.GetInt("Score_LastGame"));
			}


		} else if (level == "exterior") {
			if (!PlayerPrefs.HasKey ("Stats_Exterior_HighScore")) {
				PlayerPrefs.SetInt ("Stats_Exterior_HighScore", 0);
			}
			if (!PlayerPrefs.HasKey ("Stats_Exterior_Highest_Wave")) {
				PlayerPrefs.SetInt ("Stats_Exterior_Highest_Wave", 0);
			}
			if (!PlayerPrefs.HasKey ("Stats_Exterior_TotalKills")) {
				PlayerPrefs.SetInt ("Stats_Exterior_TotalKills", 0);
			}


			PlayerPrefs.SetInt ("Stats_Exterior_TotalKills", PlayerPrefs.GetInt("Kills_LastGame") + PlayerPrefs.GetInt("Stats_Exterior_TotalKills"));

			if (PlayerPrefs.GetInt ("Stats_Exterior_Highest_Wave") < PlayerPrefs.GetInt ("Wave_LastGame")) {
				PlayerPrefs.SetInt ("Stats_Exterior_Highest_Wave", PlayerPrefs.GetInt("Wave_LastGame"));
			}

			if (PlayerPrefs.GetInt ("Stats_Exterior_HighScore") < PlayerPrefs.GetInt ("Score_LastGame")) {
				PlayerPrefs.SetInt ("Stats_Exterior_HighScore", PlayerPrefs.GetInt("Score_LastGame"));
			}
		}
	}
}
