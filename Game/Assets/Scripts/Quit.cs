using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

	bool quit = false;

	// Update is called once per frame
	void Update () {
		if (quit == true) {
			StartCoroutine (executeQuit ());
		}
	}

	public void initiate() {
		quit = true;
	}

	IEnumerator executeQuit() {
		yield return new WaitForSeconds (2);
		Application.Quit ();
	}
}
