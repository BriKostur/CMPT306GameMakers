using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {

    GameObject nameChange;

	// Use this for initialization
	void Start () {
        nameChange = GameObject.FindGameObjectWithTag("NameHolder");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Transition()
    {
        Button nameButton = gameObject.GetComponent<Button>();
        string temp = nameButton.GetComponentInChildren<Text>().text;
        nameChange.name = temp;
        DontDestroyOnLoad(nameChange);
        SceneManager.LoadScene("LoadScene");
    }
}
