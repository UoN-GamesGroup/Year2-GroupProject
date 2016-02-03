using UnityEngine;
using System.Collections;

public class LoadingIcon : MonoBehaviour {

	public float rotationSpeed;

	void FixedUpdate () {
		transform.Rotate (0, rotationSpeed, 0);
	}
}
