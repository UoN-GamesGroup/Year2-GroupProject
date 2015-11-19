using UnityEngine;
using System.Collections;

/*
*	Spawn Manager for Interior Level
*/

public class InteriorSpawnManager : MonoBehaviour {

	public GameObject MainEnemy, SubEnemy, BossEnemy, VIPEnemy;
	
	int EnemiesInWorld, EnemiesLeftToSpawn;
	int MainEnemies, SubEnemies, Bosses, VIPEnemies;
	int SpawnDelay;
	
	InteriorWaveSystem waveSystem;
	
	void Start(){
		waveSystem = this.gameObject.GetComponent<InteriorWaveSystem>();
	}
	
	/// <summary>
	/// Is called by wave system pass wave contents.
	/// Contents of the wave will then be spawned by the spawn manager.
	/// </summary>
	public void setWaveInfo(int M, int S, int B, int V){
		MainEnemies = M; SubEnemies = S; Bosses = B; VIPEnemies = V;
		EnemiesLeftToSpawn = MainEnemies + SubEnemies + Bosses + VIPEnemies;
		StartCoroutine (spawnDirector());
	}
	
	IEnumerator spawnDirector(){
		yield return new WaitForSeconds(5); // Initial Wave Wait
		
		while(EnemiesLeftToSpawn > 0){
			
			Instantiate (getEnemy(), getSpawnLocation(), Quaternion.LookRotation(new Vector3(0,0,0)));
			
			yield return new WaitForSeconds(SpawnDelay);
			SpawnDelay = Random.Range(1,12);
		}
		Debug.Log ("Wave Completed");
		waveSystem.waveCompleted ();
	}
	
	Vector3 getSpawnLocation(){
		/******Enter Spawn Location Code Here******/
		return new Vector3(100, 100, 100);
	}
	
	//Generates and enemy to spawn
	GameObject getEnemy(){
		int n = Random.Range (1, 10);
		
		if (n <= 4 && MainEnemies != 0) {
			MainEnemies--;
			return MainEnemy;
		} else if (n >= 4 && n >= 8 && SubEnemies != 0) {
			MainEnemies--;
			return SubEnemy;
		} else if (n >= 9 && Bosses != 0) {
			MainEnemies--;
			return BossEnemy;
		} else {
			Debug.LogError("No Enemy Selected: Returned Default Enemy");
			return MainEnemy;
		}
	}
}
