using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateButtons : MonoBehaviour {

    // Number of buttons to create
    public int numberToCreate;

    public GameObject[] buttonList;

    void Start()
    {
        PopulateGrid();
    }

    void Update()
    {

    }

    void PopulateGrid()
    {
		GameObject buttonInstantiate;
        for (int i = 0; i < numberToCreate; i++)
        {
            buttonInstantiate = (GameObject)Instantiate(buttonList[i], transform);
        }
    }
}
