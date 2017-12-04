using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {

    GameObject nameChange;

	// Use this for initialization
	void Start () {
        // Find the blank object that holds the string for the custom level name
        nameChange = GameObject.FindGameObjectWithTag("NameHolder");
		Debug.Log (nameChange.name);
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
		//yield return new WaitForSeconds (2);
		yield return new WaitForSeconds(0);
		SceneManager.LoadScene ("LoadScene");
	}
}
