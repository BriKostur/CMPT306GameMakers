using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour {

	Rigidbody2D r_body;
	public Canvas levelEdit;
    GameObject flag;
 
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	public void Play() {
        flag = GameObject.FindGameObjectWithTag("Victory");
        if (flag != null) {
            flag.SendMessage("SetPlaying", true, SendMessageOptions.DontRequireReceiver);
        }

        // Stores all game objects then loops to turn off the drag and drop functionality
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
		foreach (GameObject go in allObjects) {
			go.SendMessage("disableScript", SendMessageOptions.DontRequireReceiver);
		}

        // Removes the movement constraints, of certain objects, that are present due to the level editor
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
        GameObject box = GameObject.FindGameObjectWithTag("MMGBox");
        if(player != null) {
            r_body = player.GetComponent<Rigidbody2D>();
            r_body.constraints = RigidbodyConstraints2D.None;
            r_body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (box != null)
        {
            r_body = box.GetComponent<Rigidbody2D>();
            r_body.constraints = RigidbodyConstraints2D.None;
            r_body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        // Turns off the canvas
		levelEdit.GetComponent<Canvas> ().enabled = false;
	}
}
