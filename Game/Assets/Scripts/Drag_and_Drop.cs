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

    // Checks for position of mouse click down and saves the position
	void OnMouseDown() {
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
	}
		
    // Checks for mouse drag and transforms the clicked objects based on the offset of the mouse
	void OnMouseDrag() {
		mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5.0f);
		transform.position = Camera.main.ScreenToWorldPoint (mousePosition) + offset;
		if (Input.GetKeyDown (KeyCode.Delete)) {
			if (this.tag != "Player") {
				Destroy (this.gameObject);
			}
		}

	}

    // Spawns the objects with associated scripts when their related UI buttons are clicked
	public void Spawn(GameObject toInst) {
		if (toInst == null) {
			Instantiate (this, new Vector2 (-10, 3), toInst.transform.rotation);
		} else {
			temp =(GameObject)Instantiate (toInst, new Vector2 (-10, 3), toInst.transform.rotation);
            temp.name = toInst.name;
			temp.AddComponent<Drag_and_Drop> ();
            temp.AddComponent<OnOffScript>();
			if (temp.GetComponent<Rigidbody2D> () != null) {
				temp.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}
		}
	}

	public void clearSelf(){
		Destroy (this.gameObject);
	}

}
