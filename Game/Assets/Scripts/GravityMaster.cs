using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMaster : MonoBehaviour {
	public Vector2 grav;
    public Vector2 gravb;
    public bool doUpdate;
    bool whichGrav;
	bool isInBox;
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

	void Update(){
		if (Input.GetKeyDown(KeyCode.E) && isInBox) {
			print ("Got press");
			if (whichGrav)
			{
				Physics2D.gravity = grav;
				whichGrav = !whichGrav;
			}
			else
			{
				Physics2D.gravity = gravb;
				whichGrav = !whichGrav;
			}

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
