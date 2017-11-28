using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateButtons : MonoBehaviour {
    
	private Object[] buttons;

    void Start()
    {
        PopulateGrid();
    }

    void Update()
    {

    }

    void PopulateGrid()
    {
		buttons = Resources.LoadAll("Buttons", typeof(GameObject));
		GameObject buttonInstantiate;

        // Instantiates the buttons present in the Buttons folder that is within the Resources folder
		// Buttons are in alphabetical order by default, this puts it in reverse so player is closer to the start
		for (int i = buttons.Length-1; i >= 0; i--)
        {
			buttonInstantiate = (GameObject)Instantiate(buttons[i], transform);
        }
    }
}
