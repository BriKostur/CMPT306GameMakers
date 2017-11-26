using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateButtons : MonoBehaviour {

    // Number of buttons to create
	private Object[] butons;

    void Start()
    {
        PopulateGrid();
    }

    void Update()
    {

    }

    void PopulateGrid()
    {
		butons = Resources.LoadAll("Buttons", typeof(GameObject));
		GameObject buttonInstantiate;
		//Buttons are in alphabetical order by default, this puts it in reverse so player is closer to the start
		for (int i = butons.Length-1; i >= 0; i--)
        {
			buttonInstantiate = (GameObject)Instantiate(butons[i], transform);
        }
    }
}
