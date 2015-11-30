using UnityEngine;
using System.Collections;

public class ExteriorBulletController : MonoBehaviour {
	
	float BulletSpeed = 1f;
	int damage = 50;

	void Start ()	
	{
		Destroy(gameObject, 5f); //Bullet Destoryed After 5 Seconds
	}
	
	void Update ()	
	{
		transform.Translate(0, 0, BulletSpeed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "MainEnemy") 
		{
			other.gameObject.GetComponent<ExteriorMainController> ().dealDamage (damage);
		}
		else if (other.gameObject.tag == "SubEnemy")
		{
			other.gameObject.GetComponent<ExteriorSubController> ().dealDamage (damage);
		}
		else if (other.gameObject.tag == "BossEnemy") 
		{
			other.gameObject.GetComponent<ExteriorBossController> ().dealDamage (damage);
		}
		Destroy (this.gameObject);
	}
}

