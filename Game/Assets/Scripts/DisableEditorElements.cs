using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEditorElements : MonoBehaviour {

    Rigidbody2D r_body;

	// Use this for initialization
	void Start () {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            go.SendMessage("disableScript", SendMessageOptions.DontRequireReceiver);
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        r_body = player.GetComponent<Rigidbody2D>();
        r_body.constraints = RigidbodyConstraints2D.None;
        r_body.constraints = RigidbodyConstraints2D.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
