using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	
	bool flipped;
	// Use this for initialization
	void Start () {
		GetComponent<Transform>().localPosition = new Vector3 (0.1f, -0.1f, 0f);
		flipped = false;
	}
	// Update is called once per frame
	void Update () {
		float manDir=  GameObject.Find ("OldMan").GetComponent<Rigidbody2D>().velocity.x;
		if (manDir >= 0 && flipped) {
			GetComponent<Transform> ().localPosition = new Vector3 (0.1f, -0.1f, 0f);
			GetComponent<SpriteRenderer> ().flipX = false;
			flipped = false;
		}
		else if(manDir < 0 && !flipped){
			GetComponent<Transform>().localPosition = new Vector3 (-0.1f, -0.1f, 0f);
			GetComponent<SpriteRenderer> ().flipX = true;
			flipped=true;
		}
		
	}
}
