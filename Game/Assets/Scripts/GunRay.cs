using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRay : MonoBehaviour {

	//gunRay transform
	Transform myTransform;
	//item the gun holds
	GameObject item;
	//the character
	GameObject oldMan;
	//timer for how long to show gunray when shot
	int timer;
	//if gun ray is visible
	bool rayVisible;
	//gunRay renderer
	LineRenderer myLineRend;
	//gunRay collider
	CapsuleCollider2D myColl;
	//show ray
	Vector3 visiblePos;
	//hide ray
	Vector3 hidePos;

    GameObject colObject;


	void Start () {
		//initialize
		myTransform = GetComponent<Transform>();
		item = null;
        oldMan = GameObject.FindGameObjectWithTag ("Player");
		timer = 0;
		rayVisible = false;
		myLineRend = GetComponent<LineRenderer>();
		myColl = GetComponent<CapsuleCollider2D>();
		visiblePos = new Vector3(0f, -0.03f, 0f);
		hidePos = new Vector3 (100f, 100f, -10f);

        //set gunRay to hide position
        Invoke("HideRay", 2f);
		//myTransform.localPosition = hidePos;
	}


	void Update () {
		//if fire key is pressed shoot or drop item
		if (Input.GetKeyDown (KeyCode.F)) {
			//get direction of character to set ray direction
			float manDir= oldMan.GetComponent<Rigidbody2D>().velocity.x;

			//if hold no item, display gunray
			if (item == null) {
				//set gunray position
				myTransform.localPosition = visiblePos;
			
				//set direction of ray and collider
				Vector3 lineEndPoint = myLineRend.GetPosition(1);

				//if man facing right or forward
				if (manDir >= 0) {
					//set ray direction and collider to the right
					myLineRend.SetPosition (1, new Vector3 (Mathf.Abs(lineEndPoint.x), lineEndPoint.y, lineEndPoint.z));
					myColl.offset = new Vector2(Mathf.Abs(myColl.offset.x),myColl.offset.y);
				} 

				//if man facing left
				else {
					myLineRend.SetPosition (1, new Vector3 (-(Mathf.Abs(lineEndPoint.x)), lineEndPoint.y, lineEndPoint.z));
					myColl.offset = new Vector2(-(Mathf.Abs(myColl.offset.x)),myColl.offset.y);
				}

				//set rayVisible true and reset timer
				rayVisible = true;
				timer = 0;
			
			//else place object beside old man
			} else {
				//if man facing right or forward place object to right of man
				item.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				if (manDir >= 0) {
					item.transform.position = new Vector3 (oldMan.transform.position.x + 1.5f, oldMan.transform.position.y, oldMan.transform.position.z);
				} 

				//if man facing left place object to left of man
				else {
					item.transform.position = new Vector3 (oldMan.transform.position.x + -1.5f, oldMan.transform.position.y, oldMan.transform.position.z);
				}
				item = null;
			}
		} 

		//when timer has hit 15 hide gun ray if its visible
		else if(timer > 15 && rayVisible){
			myTransform.localPosition = hidePos;
			timer = 0;
		}

		//increment timer
		timer = timer + 1;
	}

    void ObjectHide() {
        if (Time.time > 1f) {
            item = colObject;
            colObject.transform.localPosition = new Vector3(-100f, -100f, -20f);
        }


    }


	void OnTriggerEnter2D(Collider2D coll)
	{
        //get object collided with
        //GameObject collObj = coll.gameObject; 
        colObject = coll.gameObject;
        /**
		//if collided with MMGBox set and hide item
		if (collObj.tag == "MMGBox"){
			item = collObj;
			collObj.transform.localPosition = new Vector3 (-100f, -100f, -20f);
		}**/		
        if (colObject.tag == "MMGBox")
        {
            ObjectHide();

        }
	}
}
