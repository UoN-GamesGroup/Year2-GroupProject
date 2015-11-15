using UnityEngine;
using System.Collections;

public class ExteriorPlayerController : MonoBehaviour {

	//Temporary Controls: Will Change to Assigned Keys Maps and Add Controller Support Late
	public GameObject Frame;
	public GameObject Bullet;
	public GameObject BulletEmitter;

	double dY = 0;
	float fY = 0;
	float fX = 0;
	int FireLine = 0;



	void Update () {

		if (Input.GetKeyUp (KeyCode.W)) {
			FireLine++;
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			FireLine--;		
		}

		if (FireLine > 3) {
			FireLine = 0;
		}
		if (FireLine < 0) {
			FireLine = 3;
		}
		
		switch (FireLine) {
		case 0:
			fX = -20;
			break;
		case 1:
			fX = -30;
			break;
		case 2:
			fX = -42;
			break;
		}

		if (Input.GetKey (KeyCode.A)) {
			dY -= 1;
			fY = (float)dY;
		}
		if (Input.GetKey (KeyCode.D)) {
			dY += 1;
			fY = (float)dY;			
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject BulletHandler;
			BulletHandler = Instantiate(Bullet, BulletEmitter.transform.position, Quaternion.Euler (0f, fY, 0f)) as GameObject;
			
			Rigidbody rigidbody;
			rigidbody = BulletHandler.GetComponent<Rigidbody>();
			
			rigidbody.AddForce(transform.forward * 1000f);
			
			Destroy(BulletHandler, 10.0f);
		}

		transform.rotation = Quaternion.Euler (fX, fY, 0f);
		Frame.transform.rotation = Quaternion.Euler (0f, fY, 0f);
	}
}
