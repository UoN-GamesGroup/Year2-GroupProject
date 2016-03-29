using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	RawImage background;
	public Texture[] Texture;

	void Start () {
		background = GetComponent<RawImage>();
		int r = Random.Range (0, 3);
		background.texture = Texture [r];
	}
}
