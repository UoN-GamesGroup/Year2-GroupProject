using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDWave : MonoBehaviour {

	public Text waveType;
	public Text waveNum;
	string s;

	void OnGUI () {
		s = WaveManager.getWave() ? "BOSS WAVE!" : " ";
		waveType.text = s;

		waveNum.text = "Wave: " + WaveManager.wave;
	}
}