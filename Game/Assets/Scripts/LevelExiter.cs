using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEngine.UI;

public class LevelExiter : MonoBehaviour {

	public FadeTransition _fadeTransition;
	public Canvas levelEdit;
	public Canvas fade;
	public Canvas quit;
	private string storage;
	public bool yesOnQuit = false; // If yes button on quit canvas (in level editor) has not been clicked

	void Update() {
		Scene currentScene = SceneManager.GetActiveScene ();
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if (currentScene.name == "Level Editor") {
				PlayGame script = this.GetComponent<PlayGame>();
				if (script.isPlaying == true) {
					script.Stop ();
				}
				quitPrompt();
			}
			else {
				switchScene();
			}
		}
	}

	void quitPrompt() {
		quit.GetComponent<Canvas> ().enabled = true;
	}

	void switchScene() {
		StartCoroutine (executeSwitch ());
	}
		
	IEnumerator executeSwitch() {
		if (fade.enabled == false) {
			fade.enabled = true;
		}
		_fadeTransition.initiate (false);
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("Title Screen"); // Name of button must match scene name, otherwise error
		storage = (Application.persistentDataPath + "/EditScene.json");
		if (File.Exists(storage)) {
			File.Delete (storage);
		}
	}
}
