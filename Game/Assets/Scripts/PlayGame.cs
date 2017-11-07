using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour {

	Rigidbody2D r_body;
	public Canvas levelEdit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Play() {
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
		foreach (GameObject go in allObjects) {
			go.SendMessage("disableScript", SendMessageOptions.DontRequireReceiver);
		}

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		r_body = player.GetComponent<Rigidbody2D> ();
		r_body.constraints = RigidbodyConstraints2D.None;
		r_body.constraints = RigidbodyConstraints2D.FreezeRotation;
		//r_body.gravityScale = 1;
		levelEdit.GetComponent<Canvas> ().enabled = false;
	}
}
