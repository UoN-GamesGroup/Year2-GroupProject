using UnityEngine;
using System.Collections;

public class InteriorBulletController: MonoBehaviour {

	float BulletSpeed = 1f;
	int damage = 50;
	
	void Start ()	
	{
		Destroy(gameObject, 5f); //Bullet Destoryed After 5 Seconds
	}
	
	void Update ()	
	{
		transform.Translate(0, BulletSpeed, 0);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "MainEnemy") 
		{
			other.gameObject.GetComponent<InteriorMainController> ().dealDamage (damage);
		}
		else if (other.gameObject.tag == "SubEnemy")
		{
			other.gameObject.GetComponent<InteriorSubController> ().dealDamage (damage);
		}
		else if (other.gameObject.tag == "BossEnemy") 
		{
			other.gameObject.GetComponent<InteriorBossController> ().dealDamage (damage);
		}
		Destroy (this.gameObject);
	}
}
