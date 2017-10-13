using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	//true when gun flipped left
	bool flipped;
	//position of gun relative to character
	Vector3 myPos;

	void Start () {
		//initialize
		myPos = new Vector3 (0.1f, -0.1f, 0f);
		GetComponent<Transform>().localPosition = myPos;
		flipped = false;

		//create a child gunRay object 
		Instantiate((Resources.Load("GunRay") as GameObject),GetComponent<Transform>()); 
	}

	void Update () {
		//get character direction to face gun the correct way
		float manDir=  GameObject.Find ("OldMan").GetComponent<Rigidbody2D>().velocity.x;

		//if character facing right or forward and gun is facing left
		if (manDir >= 0 && flipped) {
			//set position in relation to character
			myPos.x = Mathf.Abs (myPos.x);
			GetComponent<Transform> ().localPosition = myPos;

			//flip the direction of the gun
			GetComponent<SpriteRenderer> ().flipX = false;
			flipped = false;
		}

		//if character facing left and gun is facing right
		else if(manDir < 0 && !flipped){
			//set position in relation to character
			myPos.x = -(Mathf.Abs (myPos.x));
			GetComponent<Transform>().localPosition = myPos;

			//flip the direction of the gun
			GetComponent<SpriteRenderer> ().flipX = true;
			flipped=true;
		}
		
	}
}
