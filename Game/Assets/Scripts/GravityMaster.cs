using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMaster : MonoBehaviour {
	public Vector2 grav;
    public Vector2 gravb;
    public bool doUpdate;
    bool whichGrav;
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
    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Player") {
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
}
