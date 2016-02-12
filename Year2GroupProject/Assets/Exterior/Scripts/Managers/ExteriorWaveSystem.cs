using UnityEngine;
using System.Collections;

public class ExteriorWaveSystem : MonoBehaviour {
	//TODO
	//Enemy algorithms
	
	int Wave = 1;
	int MainEnemies = 0, SubEnemies = 0, Bosses = 0, VIPEnemies = 0;
	int NextBossWave = 0, NextObjectiveWave = 0;
	
	ExteriorSpawnManager spawnManager;
	
	void Start(){
		
		spawnManager = this.gameObject.GetComponent<ExteriorSpawnManager>();
		setNextBossWave();
		setNextObjectiveWave();
		generateWave ();
	}
	
	public int getWave(){
		return Wave;
	}
	
	/// <summary>
	/// Increments wave and calls to generate the next.
	/// </summary>
	public void waveCompleted(){
		Wave++;
		MainEnemies = 0; SubEnemies = 0; Bosses = 0; VIPEnemies = 0; // Check to make sure no values transferred to next wave
		generateWave ();
	}
	
	void generateWave(){
		if (Wave == NextBossWave) {
			createBossWave();
			setNextBossWave();
			WaveManager.setWave(true);
		}else{
			createWave();
			WaveManager.setWave(false);
		}
		if (Wave == NextObjectiveWave) {
			createObjectives();
			setNextObjectiveWave();
		}
		
		spawnManager.setWaveInfo (MainEnemies, SubEnemies, Bosses, VIPEnemies); // Send wave info to spawn manager
		WaveManager.wave = Wave;
		Debug.LogFormat ("Boss Wave Generated: Main - {0}, Sub - {1}, Bosses - {2}, VIP - {3}", MainEnemies, SubEnemies , Bosses, VIPEnemies);
	}
	
	
	//BELOW CONSIDER MULTIPLAYER
	void createWave(){
		MainEnemies = (Wave * 5)+ 15;
		SubEnemies = (Wave * 4)+ 10;
	}
	
	void createBossWave(){
		//Temp wave algorithm
		MainEnemies = (Wave * 5)+ 15;
		SubEnemies = (Wave * 4)+ 10;
		Bosses = Wave;
	}
	
	void createObjectives(){
		//Temp wave algorithm
	}
	
	void setNextBossWave(){
		if (NextBossWave == 0) {
			int r = Random.Range (3, 7);
			NextBossWave = NextBossWave + r;
		} else {
			int r = Random.Range (1, 5);
			NextBossWave = NextBossWave + r;
		}
	}
	
	void setNextObjectiveWave(){
		NextObjectiveWave = NextObjectiveWave + 1;
	}
}

