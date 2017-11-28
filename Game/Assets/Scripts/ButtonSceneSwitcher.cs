using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneSwitcher : MonoBehaviour {

	void switchScene() {
		StartCoroutine (executeSwitch ());
	}

	IEnumerator executeSwitch() {
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (gameObject.name); // Name of button must match scene name, otherwise error
	}
}
