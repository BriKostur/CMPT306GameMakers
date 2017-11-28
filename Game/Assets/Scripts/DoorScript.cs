using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	public int channel;
	private SpriteRenderer spr;
	// Use this for initialization
	void Start () {
		spr = this.gameObject.GetComponent<SpriteRenderer> ();
		switch(channel){
			case 0:
			spr.color = Color.Lerp(Color.red, Color.grey, 0.6f);
				break;
			case 1:
			spr.color = Color.Lerp(Color.green, Color.grey, 0.6f);
				break;
			case 2:
			spr.color = Color.Lerp(Color.blue, Color.grey, 0.6f);
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Open (int cIn){
		if (cIn == channel) {
			this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
			spr.sprite =Resources.Load<Sprite>("door_openMid");
		}
	}

	void Close (int cIn){
		if (cIn == channel) {
				this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = false;
			spr.sprite = (Sprite)Resources.Load<Sprite>("door_closedMid");
				switch(channel){
				case 0:
				spr.color = Color.Lerp(Color.red, Color.grey, 0.6f);
					break;
				case 1:
				spr.color = Color.Lerp(Color.green, Color.grey, 0.6f);
					break;
				case 2:
				spr.color = Color.Lerp(Color.blue, Color.grey, 0.6f);
					break;
			}
		}
	}
}
