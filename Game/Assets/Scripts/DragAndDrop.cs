using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

	private Vector3 mousePosition;
	private Vector3 offset;
	private GameObject clone;
	private bool delete;

	// Use this for initialization
	void Start() {
		clone = this.gameObject;
	}

	// Update is called once per frame
	void Update() {
	}
		
	void OnMouseDown() {
		// Check to see if the object is clonable
		if (gameObject.tag == "Original") {
			clone = gameObject;
			Instantiate (clone);
			clone.tag = "Clone";
		}
		// On mouse down, clone object in front of the original
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5.0f));
	}

	// Mouse drag is already associated to the object being dragged
	void OnMouseDrag() {
		// Check for mouse position when dragging
		mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5.0f);
		// Transform the object to the mouse position
		transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + offset;

		// Delete the object if dragged into the delete box (trash bin)
		if (delete == true) {
			Destroy (gameObject);
		}
	}

	// Check for trigger with delete box (trash bin)
	void OnTriggerEnter2D(Collider2D other) {
		delete = true;
	}
}
