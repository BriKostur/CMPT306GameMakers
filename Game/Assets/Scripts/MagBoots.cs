using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagBoots : MonoBehaviour {
	Rigidbody2D phys;
	ConstantForce2D bootGrav;

	private float savedScale;
	public bool isActive = false;
	private ParticleSystem part;
	// Use this for initialization
	void Start () {
		bootGrav = GetComponentInParent<ConstantForce2D> ();
		phys = GetComponentInParent<Rigidbody2D> ();
		part = GetComponentInParent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (isActive) {
				//Stops the animation, will resume normal gravity from other check
				part.Clear ();
				part.Pause ();
                isActive = !isActive;
            } else {
				//Check if the player is touch a gravity platform
				if (GetComponentInParent<PlayerController>().canGrav){
					//Save the current gravity vector and turn on the particles
					bootGrav.force = Physics2D.gravity * phys.mass;
					part.Play ();
                    isActive = !isActive;
                }
			}
			
		}
		if (!isActive) {
			//Whenever the gravity boots are off apply the global gravity vector to the player
			bootGrav.force = Physics2D.gravity * phys.mass;
		}
	}
}
