using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDWave : MonoBehaviour {

	public Text waveType;
	public Text waveNum;

	void Update () {
		if (WaveManager.bossWave)
			waveType.text = "Boss Wave";
		else
			waveType.text = "";

		waveNum.text = "Wave: " + WaveManager.wave;
	}
}