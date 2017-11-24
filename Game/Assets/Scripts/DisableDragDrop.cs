using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDragDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            go.SendMessage("disableScript", SendMessageOptions.DontRequireReceiver);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
