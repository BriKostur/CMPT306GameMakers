using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExiter : MonoBehaviour {

	public FadeTransition _fadeTransition;
	public Canvas levelEdit;

	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			switchScene();
		}
	}

	void switchScene() {
		StartCoroutine (executeSwitch ());
	}

	IEnumerator executeSwitch() {
		Scene currentScene = SceneManager.GetActiveScene ();
		_fadeTransition.initiate (false);
		if (currentScene.name == "Level 1" || currentScene.name == "Level 2" || currentScene.name == "Level 3" || 
			currentScene.name == "Level 4" || currentScene.name == "Level 5" || currentScene.name == "Level 6") {
			yield return new WaitForSeconds (2);
			SceneManager.LoadScene ("Pre-Created Levels"); // Name of button must match scene name, otherwise error
		}
		else
		{
			levelEdit.GetComponent<Canvas> ().enabled = false;
			yield return new WaitForSeconds (2);
			SceneManager.LoadScene ("Title Screen"); // Name of button must match scene name, otherwise error
		}
	}
}
