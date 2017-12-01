using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffScript : MonoBehaviour {

	public Drag_and_Drop dragDrop;

	// Use this for initialization
	void Start () {
		dragDrop = (Drag_and_Drop)this.GetComponent ("Drag_and_Drop");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /**
    // Enables the drag and drop functionality
	public void enableScript() {
		//dragDrop.enabled = true;
        gameObject.AddComponent<Drag_and_Drop>();
	}**/

    // Disables the drag and drop functionality
	public void disableScript() {
		//Debug.Log ("disabled");
		//dragDrop.enabled = false;
		Destroy(dragDrop);
	}
		
}
