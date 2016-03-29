using UnityEngine;
using System.Collections;

public class InteriorSubProjectile : MonoBehaviour {

	float BulletSpeed = 0.3f;
	int damage = 10;

	void Start ()	
	{
		Destroy(gameObject, 5f); //Bullet Destoryed After 5 Seconds
	}

	void Update ()	
	{
		transform.Translate(0, -BulletSpeed, 0);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerHealth> ().dealDamage (damage);
			Destroy(this.gameObject);
		}
	}
}
