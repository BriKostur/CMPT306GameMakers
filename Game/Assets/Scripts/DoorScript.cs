using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	public int channel;
	private SpriteRenderer spr;
	private Color col;
	// Use this for initialization
	void Start () {
		spr = this.gameObject.GetComponent<SpriteRenderer> ();
		switch(channel){
			case 0:
				spr.color = Color.red;
				break;
			case 1:
				spr.color = Color.green;
				break;
			case 2:
				spr.color = Color.blue;
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Open (int cIn){
		if (cIn == channel) {
			print("Door opened");
			this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
			col = spr.color;
			col.a = 0.5f;
			spr.color = col;
		}
	}

	void Close (int cIn){
		if (cIn == channel) {
			this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = false;
			switch(channel){
			case 0:
				spr.color = Color.red;
				break;
			case 1:
				spr.color = Color.green;
				break;
			case 2:
				spr.color = Color.blue;
				break;
			}
		}
	}
}
