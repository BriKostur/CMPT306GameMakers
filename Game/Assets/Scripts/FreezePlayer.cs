using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour {

    Rigidbody2D r_body;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null) {
            r_body = player.GetComponent<Rigidbody2D>();
            r_body.constraints = RigidbodyConstraints2D.None;
            r_body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
