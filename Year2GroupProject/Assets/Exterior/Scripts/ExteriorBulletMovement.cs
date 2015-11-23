using UnityEngine;
using System.Collections;

public class ExteriorBulletMovement : MonoBehaviour {
	
	float BulletSpeed = 1f;
	
	void Start ()	
	{
		Destroy(gameObject, 5f); //Bullet Destoryed After 5 Seconds
	}
	
	void Update ()	
	{
		transform.Translate(0, 0, BulletSpeed);
	}
}

