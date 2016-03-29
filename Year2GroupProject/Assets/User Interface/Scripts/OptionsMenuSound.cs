using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenuSound : MonoBehaviour {
	public Slider musicSlider;
	public Slider sfxSlider;

	void Awake(){
		if (PlayerPrefs.GetFloat ("musicVolume") == 0.0f){
			PlayerPrefs.SetFloat ("musicVolume", 1.0f);
		}
		if (PlayerPrefs.GetFloat ("sfxVolume") == 0.0f){
			PlayerPrefs.SetFloat ("sfxVolume", 1.0f);
		}
		musicSlider.value = PlayerPrefs.GetFloat ("musicVolume");
		sfxSlider.value = PlayerPrefs.GetFloat ("sfxVolume");
	}

	void Update(){
		PlayerPrefs.SetFloat ("musicVolume", musicSlider.value);
		PlayerPrefs.SetFloat ("sfxVolume", sfxSlider.value);

		SoundManager.instance.musicSource.volume = musicSlider.value;
		SoundManager.instance.sfxSource.volume = sfxSlider.value;
	}
}
