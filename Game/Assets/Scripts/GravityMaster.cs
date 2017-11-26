using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMaster : MonoBehaviour {
	//These should only be used for testing thing's manually from the editor
	public Vector2 grav;
    public bool doUpdate;
    bool whichGrav;
	bool isInBox;
	void Start () {
		//grav = Physics.gravity;
		grav = this.transform.up;
		grav.x=grav.x*-9.81f;
		grav.y=grav.y*-9.81f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (doUpdate){
			Physics2D.gravity = grav;
			doUpdate = false;
		}
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.E) && isInBox) {
			if (whichGrav) {
				Physics2D.gravity = grav;
			}
			whichGrav = !whichGrav;
		}    
	}
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
			isInBox = true;
        }    
    }

	void OnTriggerExit2D(Collider2D collision){
		isInBox = false;
	}

}
