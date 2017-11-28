using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuToggle : MonoBehaviour {

    GameObject levelEdit;

	// Use this for initialization
	void Start () {
        levelEdit = GameObject.Find("Completion Menu");
        levelEdit.GetComponent<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowEndMenu() {
        if(levelEdit != null) {
            levelEdit.GetComponent<Canvas>().enabled = true;
        }
    }
}
