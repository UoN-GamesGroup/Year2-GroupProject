using UnityEngine;
using System.Collections;

public class ExteriorPlayerController : MonoBehaviour {

	//Temporary Controls: Will Change to Assigned Keys Maps and Add Controller Support Later

	public GameObject Gun;

	double dY = 0;
	float fY = 0;
	
	double dZ = 0;
	float fZ = 0;

	void Start () {
	
	}

	void FixedUpdate () {
		transform.rotation = Quaternion.Euler (0f, fY, 0f);
		Gun.transform.rotation = Quaternion.Euler (0f, fY, fZ);

		if (Input.GetKey (KeyCode.W)) {
			dZ += 1;
			fZ = (float)dZ;
		}
		if (Input.GetKey (KeyCode.S)) {
			dZ -= 1;
			fZ = (float)dZ;			
		}
		if (Input.GetKey (KeyCode.A)) {
			dY -= 1;
			fY = (float)dY;
		}
		if (Input.GetKey (KeyCode.D)) {
			dY += 1;
			fY = (float)dY;			
		}
	}
}
