using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMaster : MonoBehaviour {
	public Vector2 grav;
	public bool doUpdate;

	void Start () {
		grav = Physics.gravity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (doUpdate){
			Physics2D.gravity = grav;
			doUpdate = false;
		}
	}
}
