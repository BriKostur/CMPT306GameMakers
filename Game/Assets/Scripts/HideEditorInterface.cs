using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideEditorInterface : MonoBehaviour {

    public Canvas levelEdit;
    bool interfaceShowing = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.P) && interfaceShowing == true) {
            HideInterface();
        }
        if (Input.GetKey(KeyCode.P) && interfaceShowing == false)
        {
            ShowInterface();
        }
	}

    public void HideInterface()
    {
        levelEdit.GetComponent<Canvas>().enabled = false;
        interfaceShowing = false;
    }

    public void ShowInterface()
    {
        levelEdit.GetComponent<Canvas>().enabled = true;
        interfaceShowing = true;
    }
}
