using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDWave : MonoBehaviour {

	public Text waveType;
	public Text waveNum;
	string s;

	void OnGUI () {
		Debug.Log (WaveManager.bossWave);
		s = WaveManager.bossWave ? "BOSS WAVE!" : " ";
		waveType.text = s;

		waveNum.text = "Wave: " + WaveManager.wave;
	}
}