using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRay : MonoBehaviour {
	//item the gun holds
	GameObject item;
	Transform myTransform;
	GameObject oldMan;
	//timer for how long to show gunray when shot
	int timer;
	//if gun ray is visible
	bool rayVisible;
	LineRenderer myLineRend;
	CapsuleCollider2D myColl;
	//show ray
	Vector3 visiblePos;
	//hide ray
	Vector3 hidePos;



	// Use this for initialization
	void Start () {
		item = null;
		oldMan = GameObject.Find ("OldMan");
		myTransform = GetComponent<Transform>();
		visiblePos = new Vector3(0f, -0.03f, 0f);
		hidePos = new Vector3 (100f, 100f, -10f);
		myTransform.localPosition = hidePos;
		timer = 0;
		rayVisible = false;
		myLineRend = GetComponent<LineRenderer>();
		myColl = GetComponent<CapsuleCollider2D>();



	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			float manDir= oldMan.GetComponent<Rigidbody2D>().velocity.x;
			//if no item display gunray
			if (item == null) {
				//fire gun ray
				myTransform.localPosition = visiblePos;
				Vector3 lineEndPoint = myLineRend.GetPosition(1);

				//set direction of ray and collider
				if (manDir >= 0) {
					myLineRend.SetPosition (1, new Vector3 (Mathf.Abs(lineEndPoint.x), lineEndPoint.y, lineEndPoint.z));
					myColl.offset = new Vector2(Mathf.Abs(myColl.offset.x),myColl.offset.y);
				} else {
					myLineRend.SetPosition (1, new Vector3 (-(Mathf.Abs(lineEndPoint.x)), lineEndPoint.y, lineEndPoint.z));
					myColl.offset = new Vector2(-(Mathf.Abs(myColl.offset.x)),myColl.offset.y);
				}
				rayVisible = true;
				timer = 0;
			//else place object beside old man
			} else {
				if (manDir >= 0) {
					item.transform.position = new Vector3 (oldMan.transform.position.x + 1.5f, oldMan.transform.position.y, oldMan.transform.position.z);
				} else {
					item.transform.position = new Vector3 (oldMan.transform.position.x + -1.5f, oldMan.transform.position.y, oldMan.transform.position.z);
				}
				item = null;
			}
		//when timer has hit 15 stop gun ray
		} else if(timer > 15 && rayVisible){
			myTransform.localPosition = hidePos;
			timer = 0;
		}
		timer = timer + 1;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		GameObject collObj = coll.collider.gameObject; 
		//if collides with MMGBox set and hide item
		if (collObj.tag == "MMGBox"){
			item = collObj;
			collObj.transform.localPosition = new Vector3 (-100f, -100f, -20f);
		}			
	}
}
