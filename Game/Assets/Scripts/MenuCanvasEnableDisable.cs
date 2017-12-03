using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuCanvasEnableDisable : MonoBehaviour {

	// It's 3am and I don't fucking know anymore...

	// Get references to all canvases
	public Canvas mainTitle;
	public Canvas controls;

	public void DisableCanvas(Canvas canvasToDisable) {
		canvasToDisable.GetComponent<Canvas> ().enabled = false;
	}
		
	public void EnableCanvas(Canvas canvasToEnable) {
		canvasToEnable.GetComponent<Canvas> ().enabled = true;
	}
		
}
