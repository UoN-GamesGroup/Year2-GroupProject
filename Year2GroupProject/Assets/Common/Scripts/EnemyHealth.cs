using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    int eHealth = 200;

	// Use this for initialization
	void Start () {
	
	}

    public void dealEDamage(int value)
    {
        eHealth -= value;
    }

    public int getEnemyHealth()
    {
        return eHealth;
    }

    void Update()
    {
        Debug.Log(eHealth);
    }
}
