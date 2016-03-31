using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource sfxSource;
	public AudioSource musicSource;
	public AudioClip[] audioTracks;
	public static SoundManager instance = null;

	float lowPitchRange = 0.95f;
	float highPitchRange = 1.05f;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);	
		}

		DontDestroyOnLoad (gameObject);

		if (!PlayerPrefs.HasKey ("musicVolume")) {
			PlayerPrefs.SetFloat ("musicVolume", 1.0f);
		}
		if (!PlayerPrefs.HasKey ("sfxVolume")) {
			PlayerPrefs.SetFloat ("sfxVolume", 1.0f);
		}
	}

	void Update(){
		musicSource.volume = PlayerPrefs.GetFloat ("musicVolume");
		sfxSource.volume = PlayerPrefs.GetFloat ("sfxVolume");

		if (!musicSource.isPlaying) {
			playRandomTrack (audioTracks);
		}
	}

	public void playSingleSFX(AudioClip clip){
		sfxSource.clip = clip;
		sfxSource.Play ();
	}

	public void playRandomSFX (params AudioClip[] sfx){
		int randomIndex = Random.Range (0, sfx.Length);
		sfxSource.clip = sfx [randomIndex];
		sfxSource.Play ();
	}

	public void playRandomTrack (params AudioClip[] track){
		int randomIndex = Random.Range (0, track.Length);
		musicSource.clip = track [randomIndex];
		musicSource.Play ();
	}
}