using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

	Rigidbody2D r_body;
	public Canvas levelEdit;
    GameObject[] flag;
	GameObject musicSpeedControl;
	public bool isPlaying = false;
 
	// Use this for initialization
	void Start () {
        if (File.Exists(Application.persistentDataPath + "/EditScene.json"))
        {
            load_save script = this.GetComponent<load_save>();
            script.ReloadLevelEditor();
        }


        GameObject[] objects = SceneManager.GetSceneByName("Level Editor").GetRootGameObjects();
		foreach (GameObject obj in objects) {
			if (obj.tag != "Canvas" && obj.tag != "MainCamera" && obj.tag != "Background" && obj.tag != "Level Editor Music") {
				obj.AddComponent<Drag_and_Drop> ();
				obj.AddComponent<OnOffScript> ();
			}
        }

		GameObject deletePlayerClone = GameObject.Find("OldMan");
		if (deletePlayerClone != null&& GameObject.Find("OldMan(Clone)")!=null) {
			Destroy (deletePlayerClone);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) {
			if (levelEdit.enabled != true) {

                new reloadScene().resetScene();
			}
		}
	}

	public void Stop() {
		isPlaying = false;
		GameObject[] objects = SceneManager.GetSceneByName ("Level Editor").GetRootGameObjects ();
		foreach (GameObject obj in objects) {
			if (obj.tag != "Canvas" && obj.tag != "MainCamera" && obj.tag != "Background" && obj.tag != "Level Editor Music") {
				obj.AddComponent<Drag_and_Drop> ();
				obj.AddComponent<OnOffScript> ();
			}
			if (obj.GetComponent<Rigidbody2D> () != null) {
				obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}
		}
		levelEdit.enabled = true;
		musicSpeedControl = GameObject.FindGameObjectWithTag("Level Editor Music");
		musicSpeedControl.SendMessage ("slowAudio", SendMessageOptions.DontRequireReceiver);
	}

	public void Play() {
		isPlaying = true;
        // If the flag is not null, send a message to the EndTrigger script that the game is playing
        flag = GameObject.FindGameObjectsWithTag("Victory");
        if (flag != null) {
			for (int i = 0; i < flag.Length; i++) {
				flag[i].SendMessage ("SetPlaying", true, SendMessageOptions.DontRequireReceiver);
			}
        }
			
        // Stores all game objects then loops to turn off the drag and drop functionality
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
		foreach (GameObject go in allObjects) {
			go.SendMessage("disableScript", SendMessageOptions.DontRequireReceiver);
		}

        // Removes the movement constraints, of certain objects (mmg box and player), that are present due to the level editor
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
        GameObject box = GameObject.FindGameObjectWithTag("MMGBox");
        if(player != null) {
            r_body = player.GetComponent<Rigidbody2D>();
            r_body.constraints = RigidbodyConstraints2D.None;
            r_body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (box != null)
        {
            r_body = box.GetComponent<Rigidbody2D>();
            r_body.constraints = RigidbodyConstraints2D.None;
            r_body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        // Turns off the main canvas
		levelEdit.GetComponent<Canvas> ().enabled = false;

		musicSpeedControl = GameObject.FindGameObjectWithTag("Level Editor Music");
		musicSpeedControl.SendMessage("fastAudio", SendMessageOptions.DontRequireReceiver);
	}
}
