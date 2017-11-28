using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;
using System.IO;

public class load_save : MonoBehaviour {
	private string myFilePath = "Assets/LoadScenes/";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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



	public void Save(string levelName) {
		GameObject [] gameObjects = SceneManager.GetSceneByName("Level Editor").GetRootGameObjects(); 
		int size = gameObjects.Length;
		object_info[] info = new object_info[size];
		//Debug.Log ("in save");
		for (int i = 0; i < size; i++) {
			if (gameObjects [i].tag != "Canvas") {
				object_info myInfo = new object_info ();
				GameObject prefab = PrefabUtility.FindPrefabRoot (gameObjects [i]);
				myInfo.setName (prefab.name);
				myInfo.setLocX (gameObjects [i].transform.position.x);
				myInfo.setLocY (gameObjects [i].transform.position.y);
				myInfo.setLocZ (gameObjects [i].transform.position.z);
				myInfo.setRotW (gameObjects [i].transform.rotation.w);
				myInfo.setRotX (gameObjects [i].transform.rotation.x);
				myInfo.setRotY (gameObjects [i].transform.rotation.y);
				myInfo.setRotZ (gameObjects [i].transform.rotation.z);
				info [i] = myInfo;
			}
		}
			
		string infoToJson = JsonHelper.ToJson(info);
		File.WriteAllText (myFilePath + levelName + ".json", infoToJson);
		AssetDatabase.Refresh ();

	}

	void Load(string levelName){
		Debug.Log("IN LOAD");
		if (File.Exists (myFilePath + levelName + ".json")) {
			string dataAsJson = File.ReadAllText (myFilePath + levelName + ".json");
			object_info[] returnInfo = JsonHelper.FromJson<object_info> (dataAsJson);
			Camera myCam = Camera.main;
			myCam.transform.position = new Vector3 (returnInfo [0].getLocX (), returnInfo [0].getLocY (), returnInfo [0].getLocZ ());
			for (int i = 1; i < returnInfo.Length; i++) {
				UnityEngine.Object myObj = Resources.Load (returnInfo [i].getPrefabName ());
				if (myObj != null) {
					Instantiate (Resources.Load (returnInfo [i].getPrefabName ()),
						new Vector3 (returnInfo [i].getLocX (), returnInfo [i].getLocY (), returnInfo [i].getLocZ ()),
						new Quaternion (returnInfo [i].getRotW (), returnInfo [i].getRotX (), returnInfo [i].getRotY (), returnInfo [i].getRotZ ()));
				} else {
					Debug.Log ("null at index " + i + " name " + returnInfo [i].getPrefabName ());
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


}


