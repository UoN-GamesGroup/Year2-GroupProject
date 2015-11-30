using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DevStressSpawning : MonoBehaviour {

	public GameObject spawnObject;
	public Text counterLabel;

	int counter = 0;
	// Update is called once per frame
	void Start () {
		InvokeRepeating ("spawn", 1, 1);
	}

	void spawn(){
		Instantiate (spawnObject, transform.position, transform.rotation);
		counter++;
		counterLabel.text = "Total Spawned: " + counter;
	}
}
