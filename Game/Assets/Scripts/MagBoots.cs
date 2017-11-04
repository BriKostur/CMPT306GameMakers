using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagBoots : MonoBehaviour {
	Rigidbody2D phys;
	//Vector2 savedGrav;
	ConstantForce2D bootGrav;

	public float savedScale;
	public bool isActive = false;
	// Use this for initialization
	void Start () {
		bootGrav = GetComponentInParent<ConstantForce2D> ();
		phys = GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (isActive) {
				bootGrav.force = new Vector2 (0,0);
			} else {
				savedScale = phys.gravityScale;
				phys.gravityScale = 0f;	
				print ("Things"+phys.gravityScale);
		
				bootGrav.force = Physics2D.gravity * phys.mass;
			}
			isActive = !isActive;
		}
		if (!isActive) {
			bootGrav.force = Physics2D.gravity * phys.mass;
		}
	}
}
