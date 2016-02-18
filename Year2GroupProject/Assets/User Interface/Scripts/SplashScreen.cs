using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public GameObject splashLogo;
	public float scaleFactor = 0.0f;
	public float speedDampener = 0.0f;
	public float scaleLimit = 0.23f;

	static string scene = "MainMenu";
	// Use this for initialization
	void Start () {
		Invoke ("callChangeScreen", 5.0f);
	}

	void Update(){
		if (splashLogo.transform.localScale.x <= scaleLimit){
			splashLogo.transform.localScale += new Vector3 (scaleFactor, scaleFactor, scaleFactor);
			scaleFactor -= speedDampener;
		}
	}

	void callChangeScreen(){
		ChangeScene.changeSceneTo (ref scene);
	}
}
