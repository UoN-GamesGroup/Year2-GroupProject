using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public static void changeSceneTo (ref string sceneName) {
		Debug.Log ("Scene Change Called");
		SceneManager.LoadScene (sceneName);
	}

	public void exitGame(){
		Application.Quit ();
	}
}
