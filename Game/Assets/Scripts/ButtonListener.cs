using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonListener : MonoBehaviour {

	public Renderer rend;
	public bool insideButtonBounds = false;

	void Start() {
		rend = GetComponent<Renderer>();
	}

	void OnMouseEnter() {
		insideButtonBounds = true;
		rend.material.color = Color.yellow;
		Debug.Log ("Mouse entered");
	}

	void OnMouseExit() {
		insideButtonBounds = false;
		rend.material.color = Color.white;
	}
		
	void OnMouseUp() {
		if (insideButtonBounds == true) {
			SceneManager.LoadScene (gameObject.name); // Name of button must match scene name, otherwise crash
			Debug.Log(gameObject.name);
		}
	}
}

//	void OnMouseOver() {
//		rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
//	}
