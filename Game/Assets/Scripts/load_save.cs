using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor;
using System;
using System.IO;
using UnityEngine.UI;

public class load_save : MonoBehaviour {
	private string myFilePath;
	private string tempFilePath;
	private string tempMetaPath;
	private string jsonString;
	// Use this for initialization
	void Start () {
		print ("Saving to" + Application.persistentDataPath);
		myFilePath = (Application.persistentDataPath+"/");
		tempFilePath = (Application.persistentDataPath + "/EditScene.json");
	}


	public static class JsonHelper
	{
		public static T[] FromJson<T>(string json)
		{
			Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
			return wrapper.Items;
		}

		public static string ToJson<T>(T[] array)
		{
			Wrapper<T> wrapper = new Wrapper<T>();
			wrapper.Items = array;
			return JsonUtility.ToJson(wrapper);
		}

		public static string ToJson<T>(T[] array, bool prettyPrint)
		{
			Wrapper<T> wrapper = new Wrapper<T>();
			wrapper.Items = array;
			return JsonUtility.ToJson(wrapper, prettyPrint);
		}

		[Serializable]
		private class Wrapper<T>
		{
			public T[] Items;
		}
	}


	//Call on play in the level editor
	public void Save() {
		GameObject [] gameObjects = SceneManager.GetSceneByName("Level Editor").GetRootGameObjects(); 
		int size = gameObjects.Length;
		object_info[] info = new object_info[size];
		int offSet = 2; //Offset helps us put the camera and backgournd first
		for (int i = 0; i < size; i++) {
			if (gameObjects [i].tag != "Canvas") {
				object_info myInfo = new object_info ();
				GameObject prefab = gameObjects [i];

                int clonePos = prefab.name.IndexOf("(Clone)");
                String myName = prefab.name;

                if (clonePos > 0)
                {
                    myName = myName.Substring(0, clonePos);
                }

                Debug.Log(prefab.name);
				myInfo.setName (myName);
				myInfo.setLocX (gameObjects [i].transform.position.x);
				myInfo.setLocY (gameObjects [i].transform.position.y);
				myInfo.setLocZ (gameObjects [i].transform.position.z);
				myInfo.setRotW (gameObjects [i].transform.rotation.w);
				myInfo.setRotX (gameObjects [i].transform.rotation.x);
				myInfo.setRotY (gameObjects [i].transform.rotation.y);
				myInfo.setRotZ (gameObjects [i].transform.rotation.z);
				if (myName == "Main Camera") { //This part makes sure that the Camera and backgournd always come first
					info[i] = info [0];
					info [0] = myInfo;
					offSet--;
				}else if(myName == "Background") {
					info[i] = info [1];
					info [1] = myInfo;
					offSet--;
				}
				info [i] = myInfo;
			}
		}
		jsonString = JsonHelper.ToJson (info);
		File.WriteAllText (tempFilePath, jsonString);
		//AssetDatabase.Refresh ();


	}

	//call on save from the level editor
	public void SendFile(){

        InputField mainInput = UnityEngine.Object.FindObjectOfType<InputField>();
        if(mainInput.text != "") {
            string dataAsJson = File.ReadAllText(tempFilePath);
            File.WriteAllText(myFilePath + mainInput.text + ".json", dataAsJson);
           // AssetDatabase.DeleteAsset(tempFilePath);

          //  AssetDatabase.Refresh();
        }
	}

	//call when loading from the main menu
	public void Load(string levelName ){
		if (File.Exists (myFilePath + levelName + ".json")) {
			string dataAsJson = File.ReadAllText (myFilePath + levelName + ".json");
			object_info[] returnInfo = JsonHelper.FromJson<object_info> (dataAsJson);
			Camera myCam = Camera.main;
			myCam.transform.position = new Vector3 (returnInfo [0].getLocX (), returnInfo [0].getLocY (), returnInfo [0].getLocZ ());
            myCam.orthographicSize = 11.58f;
			for (int i = 1; i < returnInfo.Length; i++) {
				UnityEngine.Object myObj = Resources.Load (returnInfo [i].getPrefabName ());
				if (myObj != null) {
                    Debug.Log(returnInfo[i].getRotX());
					Instantiate (Resources.Load (returnInfo [i].getPrefabName ()),
						new Vector3 (returnInfo [i].getLocX (), returnInfo [i].getLocY (), returnInfo [i].getLocZ ()),
                                 new Quaternion(returnInfo[i].getRotX(), returnInfo [i].getRotY (), returnInfo [i].getRotZ (), returnInfo[i].getRotW()));
				} else {
					Debug.Log ("null at index " + i + " name " + returnInfo [i].getPrefabName ());
				}
			}
		} 
	}

	//call when reloading level editor
	public void ReloadLevelEditor(){
        tempFilePath = (Application.persistentDataPath + "/EditScene.json");
        if (File.Exists(tempFilePath)) {
            string dataAsJson = File.ReadAllText (tempFilePath);

            object_info[] returnInfo = JsonHelper.FromJson<object_info> (dataAsJson);
			Camera myCam = Camera.main;
			myCam.transform.position = new Vector3 (returnInfo [0].getLocX (), returnInfo [0].getLocY (), returnInfo [0].getLocZ ());
			for (int i = 1; i < returnInfo.Length; i++) {
                UnityEngine.Object myObj = Resources.Load (returnInfo [i].getPrefabName ());
				if (myObj != null) {
                    Instantiate (Resources.Load (returnInfo [i].getPrefabName ()),
						new Vector3 (returnInfo [i].getLocX (), returnInfo [i].getLocY (), returnInfo [i].getLocZ ()),
                                 new Quaternion(returnInfo[i].getRotX(), returnInfo[i].getRotY(), returnInfo[i].getRotZ(),returnInfo[i].getRotW()));
				} else {
					Debug.Log ("null at index " + i + " name " + returnInfo [i].getPrefabName ());
				}
			}

		} 
	}
}


	//this was for testing. IT WILL BE REPLACED WITH BUTTON PRESS
	//void OnTriggerEnter2D(Collider2D col){
	//	if (this.name == "SavObj") {
	//		Save ("fun");
	//	} else if((this.name == "LoadObj")){
	//		Load ("fun");
	//	}
	//}





