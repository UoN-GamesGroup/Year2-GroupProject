﻿using UnityEngine;
using System.Collections;

public class WaveSystem : MonoBehaviour {

	//TODO
		//Set and find spawn manager
		//Enemy algorithms
		//Send info to spawn manager

	int Wave = 1;
	int MainEnemies, SubEnemies, Bosses, VIPEnemies;
	int NextBossWave, NextObjectiveWave;

	void Start(){
		setNextBossWave();
		setNextObjectiveWave();
		generateWave ();
	}

	public int getWave(){
		return Wave;
	}

	/// <summary>
	/// Increments wave and calls to generate the next
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

		//spawnManager.setWaveInfo(MainEnemies, SubEnemies, Bosses - Sends Wave to Spawn Manager

		Debug.LogFormat ("Boss Wave Generated: Main - {0}, Sub - {1}, Bosses - {2}, VIP - {3}", MainEnemies, SubEnemies , Bosses, VIPEnemies);
	}

	void createWave(){
		//Temp wave algorithm
		MainEnemies = 0 + 10;
		SubEnemies = 0 + 10;
	}

	void createBossWave(){
		//Temp wave algorithm
		MainEnemies = 0 + 10;
		SubEnemies = 0 + 10;
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
