using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExiter : MonoBehaviour {

	public FadeTransition _fadeTransition;
	public Canvas levelEdit;
	public Canvas fade;

	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			switchScene();
		}
	}

	void switchScene() {
		StartCoroutine (executeSwitch ());
	}

	IEnumerator executeSwitch() {
		if (fade.enabled == false) {
			fade.enabled = true;
		}
		Scene currentScene = SceneManager.GetActiveScene ();
		_fadeTransition.initiate (false);
		if (currentScene.name == "Level Editor") {
			levelEdit.GetComponent<Canvas> ().enabled = false;
		}
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("Title Screen"); // Name of button must match scene name, otherwise error
	}
}
