using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {

    GameObject nameChange;
	GameObject bgmusic;
	GameObject bgfade;

	// Use this for initialization
	void Start () {
        // Find the blank object that holds the string for the custom level name
        nameChange = GameObject.FindGameObjectWithTag("NameHolder");
//		Debug.Log (nameChange.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Transition()
    {
        // Procedure for getting the name of the NameHolder object and moving the object to the custom level
        Button nameButton = gameObject.GetComponent<Button>();
        string temp = nameButton.GetComponentInChildren<Text>().text;
        nameChange.name = temp;
        DontDestroyOnLoad(nameChange);
		StartCoroutine (WaitForFades ());
    }

	// Coroutine to add delay for fade effects to complete before switching scenes
	IEnumerator WaitForFades() {
		bgmusic = GameObject.FindGameObjectWithTag("Level Editor Music");
		bgmusic.SendMessage ("initiate", SendMessageOptions.DontRequireReceiver);
		bgfade = GameObject.Find ("Canvas Fade");
		bgfade.GetComponent<Canvas> ().enabled = true;
		bgfade = GameObject.Find ("Image Fade");
		bgfade.SendMessage ("initiateUCLFade", SendMessageOptions.DontRequireReceiver);
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene ("LoadScene");
	}
}
