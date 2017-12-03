using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListener : MonoBehaviour {

	public Renderer rend;
	public bool insideButtonBounds = false;

	void Start() {
		rend = GetComponent<Renderer>();
	}

	void OnMouseEnter() {
		insideButtonBounds = true;
		rend.material.color = Color.yellow;
	}

	void OnMouseExit() {
		insideButtonBounds = false;
		rend.material.color = Color.white;
	}
}