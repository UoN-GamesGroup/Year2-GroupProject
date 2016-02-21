using UnityEngine;
using System.Collections;

/*
*	Spawn Manager for Interior Level
*/

public class InteriorSpawnManager : MonoBehaviour {

	public GameObject[] Spawns;
	public GameObject[] Terminals;
	public GameObject MainEnemy, SubEnemy, BossEnemy, VIPEnemy;
	
	int EnemiesLeftToSpawn;
	int MainEnemies, SubEnemies, Bosses, DefendObjective, VIPObjective;
	int SpawnDelay;
	bool DefendObjectiveActive = false, VIPObjectiveActive = false;
	bool NewWaveCalled;
	
	InteriorWaveSystem waveSystem;
	
	void Start(){
		waveSystem = this.gameObject.GetComponent<InteriorWaveSystem>();
	}

	void Update(){
		DefendObjectiveActive = false;
		foreach (GameObject Terminal in Terminals) {
			bool active = Terminal.gameObject.GetComponent<InteriorTerminal> ().getActive();
			if (active == true) {
				DefendObjectiveActive = true;
				break;
			}
		}

		GameObject[] VIP = GameObject.FindGameObjectsWithTag ("VIPEnemy");
		if (VIP.Length > 0) {
			VIPObjectiveActive = true;
		}

		if (EnemiesLeftToSpawn <= 0 && DefendObjective <= 0 && VIPObjective <= 0) {
			int EnemiesInWorld = 0;
			GameObject[] TypeofEnemyInWorld;

			TypeofEnemyInWorld = GameObject.FindGameObjectsWithTag ("MainEnemy");
			EnemiesInWorld += TypeofEnemyInWorld.Length;

			TypeofEnemyInWorld = GameObject.FindGameObjectsWithTag ("SubEnemy");
			EnemiesInWorld += TypeofEnemyInWorld.Length;

			TypeofEnemyInWorld = GameObject.FindGameObjectsWithTag ("BossEnemy");
			EnemiesInWorld += TypeofEnemyInWorld.Length;

			if (EnemiesInWorld == 0 && DefendObjectiveActive == false && VIPObjectiveActive == false) {
				if (NewWaveCalled == false){
					waveCompleted ();
					NewWaveCalled = true;
				}
			}
		}
	}

	/// <summary>
	/// Is called by wave system pass wave contents.
	/// Contents of the wave will then be spawned by the spawn manager.er
	/// </summary>
	public void setWaveInfo(int M, int S, int B, int DO, int VIPO){
		MainEnemies = M; SubEnemies = S; Bosses = B; DefendObjective = DO; VIPObjective = VIPO;
		EnemiesLeftToSpawn = MainEnemies + SubEnemies + VIPObjective;
		NewWaveCalled = false;
		StartCoroutine (spawnDirector());
	}
	
	IEnumerator spawnDirector(){
		yield return new WaitForSeconds(5); // Initial Wave Wait

		while(EnemiesLeftToSpawn > 0){

			if (DefendObjectiveActive == false && VIPObjectiveActive == false) {
				int r = Random.Range (1, 3);
				if (r == 1) {
					Instantiate (VIPEnemy, getSpawnLocation(), Quaternion.LookRotation(new Vector3(0,0,0)));
					VIPObjective--;
					Debug.Log ("VIP IS OUT!");
				} else {
					spawnDefendObjective();
					DefendObjective--;
				}
			}

			Instantiate (getEnemy(), getSpawnLocation(), Quaternion.LookRotation(new Vector3(0,0,0)));
			
			yield return new WaitForSeconds(SpawnDelay);
			SpawnDelay = Random.Range(1,8);
		}
	}

	Vector3 getSpawnLocation(){
		int r = Random.Range (0, 5);
		return Spawns [r].transform.position;
	}

	//Generates and enemy to spawn
	GameObject getEnemy(){
		int n = Random.Range (1, 9);
		GameObject EnemyGenerated;

		while (true){
			if (n <= 4 && MainEnemies != 0) {
				MainEnemies--;
				EnemyGenerated = MainEnemy;
				break;
			} else if (n >= 4 && n <= 8 && SubEnemies != 0) {
				SubEnemies--;
				EnemyGenerated = SubEnemy;
				break;
			} else if (n >= 9 && Bosses != 0) {
				Bosses--;
				EnemyGenerated = BossEnemy;
				break;
			}
		}

		return EnemyGenerated;
	}

	void spawnDefendObjective(){
		int r = Random.Range (0, Terminals.Length);
		Terminals [r].GetComponent<InteriorTerminal> ().setActive (true);
	}

	void waveCompleted(){
		waveSystem.waveCompleted ();
	}
}
