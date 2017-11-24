using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

public class load_save : MonoBehaviour {

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



	public void Save() {
		GameObject [] gameObjects = SceneManager.GetSceneByName("loads_save").GetRootGameObjects(); 
		int size = gameObjects.Length;
		//Debug.Log ("length of gameobjects" +size);
		object_info[] info = new object_info[size];

		for (int i = 0; i < size; i++) {
			object_info myInfo = new object_info();
			//this.gameObject.AddComponent<object_info> ();
			PrefabType curObj  = PrefabUtility.GetPrefabType(gameObjects [i]);
			myInfo.setName (curObj.ToString());
			myInfo.setLocX (gameObjects [i].transform.position.x);
			//Debug.Log ("locX is" + myInfo.getLocX());
			myInfo.setLocY ( gameObjects [i].transform.position.y);
			myInfo.setLocZ( gameObjects [i].transform.position.z);
			myInfo.setRotW (gameObjects [i].transform.rotation.w);
			myInfo.setRotX(gameObjects [i].transform.rotation.x);
			myInfo.setRotY ( gameObjects [i].transform.rotation.y);
			myInfo.setRotZ ( gameObjects [i].transform.rotation.z);
			info [i] = myInfo;
			Debug.Log (info [i].getLocX());
		}

		//Convert to Jason
		string infoToJason = JsonHelper.ToJson(info, true);
		Debug.Log(infoToJason);
	}

	void OnTriggerEnter2D(Collider2D col){
		Save ();
	}

}


