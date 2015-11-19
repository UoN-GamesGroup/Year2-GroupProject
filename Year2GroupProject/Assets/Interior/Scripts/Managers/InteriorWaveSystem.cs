using UnityEngine;
using System.Collections;

public class InteriorWaveSystem : MonoBehaviour {

	//TODO
		//Enemy algorithms

	int Wave = 1;
	int MainEnemies = 0, SubEnemies = 0, Bosses = 0, VIPEnemies = 0;
	int NextBossWave = 0, NextObjectiveWave = 0;

	InteriorSpawnManager spawnManager;

	void Start(){

		spawnManager = this.gameObject.GetComponent<InteriorSpawnManager>();

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
		}else{
			createWave();
		}
		if (Wave == NextObjectiveWave) {
			createObjectives();
			setNextObjectiveWave();
		}

		spawnManager.setWaveInfo (MainEnemies, SubEnemies, Bosses, VIPEnemies); // Send wave info to spawn manager

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
	}

	void createObjectives(){
		//Temp wave algorithm
	}

	void setNextBossWave(){
		NextBossWave = NextBossWave + 1;
	}

	void setNextObjectiveWave(){
		NextObjectiveWave = NextObjectiveWave + 1;
	}
}
