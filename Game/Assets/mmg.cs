using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mmg : MonoBehaviour {
	GameObject item;
	Transform myTransform;
	GameObject oldMan;
	int timer;
	// Use this for initialization
	void Start () {
		item = null;
		oldMan = GameObject.Find ("OldMan");
		myTransform = GameObject.FindGameObjectWithTag ("GunRay").transform;
		//hide gunray
		myTransform.localPosition = new Vector3 (100f, 100f, -10f);
		timer = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) { 
			//if no item display gunray
			if (item == null) {
				myTransform.localPosition = new Vector3 (0f, 0f, 0f);
				timer = 0;
				//else place object beside old man
			} else {
				item.transform.position = new Vector3 (oldMan.transform.position.x + 1f, oldMan.transform.position.y, oldMan.transform.position.z);
				item = null;
			}
		} else if(timer > 15){
			myTransform.localPosition = new Vector3 (100f, 100f, -10f);
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
