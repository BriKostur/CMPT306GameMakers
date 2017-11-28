using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScreenImageDrawer : MonoBehaviour {

	public Renderer rend;
	public bool insideImageBounds = false;

	void Start() {
		rend = GetComponent<Renderer>();
		rend.material.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
	}
		
	void OnMouseEnter() {
		insideImageBounds = true;
		rend.material.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
	}

	void OnMouseExit() {
		insideImageBounds = true;
		rend.material.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
	}
}
