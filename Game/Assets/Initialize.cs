using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        // Procedure for getting the changing the custom level name frm the Name Holder object
        GameObject holder = GameObject.FindGameObjectWithTag("NameHolder");
        load_save script = this.GetComponent<load_save>();
        script.Load(holder.name);
	}
}
