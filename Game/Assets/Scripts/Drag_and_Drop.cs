using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_and_Drop : MonoBehaviour {
	
	private Vector3 offset;
	private Vector3 mousePosition;
	private GameObject temp;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
	}
		
	void OnMouseDrag() {
		/**
		if (gameObject.tag != "Prefab") {
			mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5.0f);
			transform.position = Camera.main.ScreenToWorldPoint (mousePosition) + offset;
		}
		**/
		mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5.0f);
		transform.position = Camera.main.ScreenToWorldPoint (mousePosition) + offset;
	}

	public void Spawn(GameObject toInst) {
		if (toInst == null) {
			Instantiate (this, new Vector2 (-10, 3), toInst.transform.rotation);
		} else {
			Instantiate (toInst, new Vector2 (-10, 3), toInst.transform.rotation);
		}
	}
}
