using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class LevelButtons : MonoBehaviour {

	private string myFilePath;
    private Object buttons;

    // Use this for initialization
    void Start () {
		print("PathAt"+Application.persistentDataPath+"/");
		myFilePath = Application.persistentDataPath+"/";
        PopulateGrid();

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void PopulateGrid()
    {
        DirectoryInfo dir = new DirectoryInfo(myFilePath);
        FileInfo[] info = dir.GetFiles("*.json");
        buttons = Resources.Load("NoNameButton");

        foreach (FileInfo i in info)
        {
            
            GameObject buttonInstantiate = (GameObject)Instantiate(buttons, transform);
            Button nameButton = buttonInstantiate.GetComponent<Button>();
            nameButton.name = Path.GetFileNameWithoutExtension(i.ToString());
            Text temp = nameButton.GetComponentInChildren<Text>();
            temp.text = Path.GetFileNameWithoutExtension(i.ToString());
//            Debug.Log(Path.GetFileNameWithoutExtension(i.ToString()));

        }

        // Instantiates the buttons present in the Buttons folder that is within the Resources folder
        // Buttons are in alphabetical order by default, this puts it in reverse so player is closer to the start
    }
}
