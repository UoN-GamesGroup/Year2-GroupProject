using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	void Start(){
		Cursor.visible = true;
	}

	public GameObject loadingContents;
	bool loadScene = false;

	public static void changeSceneTo (ref string sceneName) {
		Debug.Log ("Scene Change Called");
		SceneManager.LoadScene (sceneName);
	}

	public void changeSceneTo (string sceneName) {
		SceneManager.LoadScene (sceneName);
	}

	public void LoadLevel(string sceneName){
		StartCoroutine(LoadScene(sceneName));
		loadingContents.SetActive (true);
	}

	public void exitGame(){
		Application.Quit ();
	}


	IEnumerator LoadScene(string sceneName) {

		yield return new WaitForSeconds(3);

		AsyncOperation async = Application.LoadLevelAsync(sceneName);

		while (!async.isDone) {
			yield return null;
		}

	}
}
