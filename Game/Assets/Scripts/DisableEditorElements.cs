using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEditorElements : MonoBehaviour {

    Rigidbody2D r_body;

	// Use this for initialization
	void Start () {
        // Stores all game objects then loops to turn off the drag and drop functionality
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            go.SendMessage("disableScript", SendMessageOptions.DontRequireReceiver);
        }

        // Removes the players movement constraints that are present due to the level editor
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null) {
            r_body = player.GetComponent<Rigidbody2D>();
            r_body.constraints = RigidbodyConstraints2D.None;
            r_body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        // Removes the mmgbox's movement constraints that are present due to the level editor
        GameObject[] box = GameObject.FindGameObjectsWithTag("MMGBox");
        foreach (GameObject obj in box) {
            r_body = obj.GetComponent<Rigidbody2D>();
            r_body.constraints = RigidbodyConstraints2D.None;
            r_body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
