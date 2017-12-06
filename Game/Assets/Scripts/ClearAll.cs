using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Clear () {
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
		foreach (GameObject go in allObjects) {
			if (go.tag != "Player") {
				go.SendMessage ("clearSelf", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
