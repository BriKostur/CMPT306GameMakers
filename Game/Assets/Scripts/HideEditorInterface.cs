using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideEditorInterface : MonoBehaviour {

    public Canvas levelEdit;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        // Check for key input for toggling canvas visibility
        if (Input.GetKeyDown(KeyCode.P))
        {
            levelEdit.enabled = !levelEdit.enabled;
        }
	}
}
