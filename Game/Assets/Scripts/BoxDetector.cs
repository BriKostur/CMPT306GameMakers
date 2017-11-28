using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetector: MonoBehaviour {
	private GameObject[] doors;
	public int channel;
	void Start () {
		switch(channel){
		case 0:
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			break;
		case 1:
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
			break;
		case 2:
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.blue;
			break;
		}
	}

    void OnTriggerStay2D(Collider2D collision)
    {
		doors = GameObject.FindGameObjectsWithTag("Door");
        if (collision.gameObject.tag == "MMGBox") {
			for (int i = 0; i < doors.Length; i++) {
				doors[i].SendMessage ("Open", channel);
			}
        }    
    }
		
	void OnTriggerExit2D(Collider2D collision){
		for (int i = 0; i < doors.Length; i++) {
			doors[i].SendMessage ("Close", channel);
		}
	}
}
