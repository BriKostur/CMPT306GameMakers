using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScrollBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        GameObject scroll = transform.Find("ScrollBar Vertical").gameObject;
        scroll.SetActive(true);
    }
}
