using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuToggle : MonoBehaviour {

    GameObject levelEdit;
	GameObject levelEditMain;
	GameObject cam;

	// Use this for initialization
	void Start () {
        levelEdit = GameObject.Find("Completion Menu");
        levelEdit.GetComponent<Canvas>().enabled = false;
		levelEditMain = GameObject.Find ("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowEndMenu() {
        if(levelEdit != null) {
            levelEdit.GetComponent<Canvas>().enabled = true;
			cam = GameObject.FindWithTag("MainCamera");
			cam.SendMessage ("Stop", SendMessageOptions.DontRequireReceiver);
			levelEditMain.GetComponent<Canvas> ().enabled = false;
        }
    }
}
