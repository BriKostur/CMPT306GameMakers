using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Reloading the scene
    public void resetScene() {
		Physics2D.gravity = new Vector2 (0f,-9.81f);
        SceneManager.LoadScene("Level Editor");
    }
}
