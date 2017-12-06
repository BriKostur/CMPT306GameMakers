using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	//position of gun relative to character
	Vector3 myPos;

	void Start () {
		//initialize
		myPos = new Vector3 (0.1f, -0.1f, 0f);
		GetComponent<Transform>().localPosition = myPos;

		//create a child gunRay object 
		Instantiate((Resources.Load("GunRay") as GameObject),GetComponent<Transform>()); 
	}

	void Update () {
		//get direction to face gun the correct way
		int gunDir = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>().directionFacing;

		//if gun facing right
		if (gunDir == 1) {
			//set position in relation to character
			myPos.x = Mathf.Abs (myPos.x);
			GetComponent<Transform> ().localPosition = myPos;

			//flip the direction of the gun
			GetComponent<SpriteRenderer> ().flipX = false;
		}

		//if gun facing left
		else if (gunDir == 0) {
			//set position in relation to character
			myPos.x = -(Mathf.Abs (myPos.x));
			GetComponent<Transform>().localPosition = myPos;

			//flip the direction of the gun
			GetComponent<SpriteRenderer> ().flipX = true;
		}
		
	}
}
