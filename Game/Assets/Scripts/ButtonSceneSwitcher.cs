using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneSwitcher : MonoBehaviour {

	public float time; // Wait time before scene switch

	public void switchScene() {
		StartCoroutine (executeSwitch ());
	}

	IEnumerator executeSwitch() {
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (gameObject.name); // Name of button must match scene name, otherwise error
	}
}
