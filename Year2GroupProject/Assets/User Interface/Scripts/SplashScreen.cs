using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	static string scene = "MainMenu";
	// Use this for initialization
	void Start () {
		Invoke ("callChangeScreen", 3.0f);
	}
	
	void callChangeScreen(){
		ChangeScene.changeSceneTo (ref scene);
	}
}
