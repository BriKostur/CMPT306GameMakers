using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSave : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		load_save script = new load_save();
		this.gameObject.AddComponent<load_save> ();
		script.Save ();
	}
}
