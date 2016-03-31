using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatsMenu : MonoBehaviour {
	
	public Text I_HighScore;
	public Text I_Highest_Wave;
	public Text I_Total_Kills;
	public Text E_HighScore;
	public Text E_Highest_Wave;
	public Text E_Total_Kills;

	void Start(){
		//Check Variables Exist
		if (!PlayerPrefs.HasKey ("Stats_Interior_HighScore")) {
			PlayerPrefs.SetInt ("Stats_Interior_HighScore", 0);
		}
		if (!PlayerPrefs.HasKey ("Stats_Interior_Highest_Wave")) {
			PlayerPrefs.SetInt ("Stats_Interior_Highest_Wave", 0);
		}
		if (!PlayerPrefs.HasKey ("Stats_Interior_TotalKills")) {
			PlayerPrefs.SetInt ("Stats_Interior_TotalKills", 0);
		}

		if (!PlayerPrefs.HasKey ("Stats_Exterior_HighScore")) {
			PlayerPrefs.SetInt ("Stats_Exterior_HighScore", 0);
		}
		if (!PlayerPrefs.HasKey ("Stats_Exterior_Highest_Wave")) {
			PlayerPrefs.SetInt ("Stats_Exterior_Highest_Wave", 0);
		}
		if (!PlayerPrefs.HasKey ("Stats_Exterior_TotalKills")) {
			PlayerPrefs.SetInt ("Stats_Exterior_TotalKills", 0);
		}
			
		I_HighScore.text = "High Score: " + PlayerPrefs.GetInt ("Stats_Interior_HighScore").ToString().PadLeft(6, '0');
		I_Highest_Wave.text = "Highest Wave: " + PlayerPrefs.GetInt ("Stats_Interior_Highest_Wave").ToString ();
		I_Total_Kills.text = "Total Kills: " + PlayerPrefs.GetInt ("Stats_Interior_TotalKills").ToString();

		E_HighScore.text = "High Score: " + PlayerPrefs.GetInt ("Stats_Exterior_HighScore").ToString().PadLeft(6, '0');
		E_Highest_Wave.text = "Highest Wave: " + PlayerPrefs.GetInt ("Stats_Exterior_Highest_Wave").ToString();
		E_Total_Kills.text = "Total Kills: " + PlayerPrefs.GetInt ("Stats_Exterior_TotalKills").ToString();
	}
}


