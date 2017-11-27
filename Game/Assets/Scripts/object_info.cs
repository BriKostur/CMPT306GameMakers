using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class object_info  {
	[SerializeField]
	string prefabName;
	[SerializeField]
	float locX;
	[SerializeField]
	float locY;
	[SerializeField]
	float locZ;
	[SerializeField]
	float rotW;
	[SerializeField]
	float rotX;
	[SerializeField]
	float rotY;
	[SerializeField]
	float rotZ;


	public void setName(string name){
		prefabName = name;
	}
	public void setLocX(float x){
		locX = x;
	}
	public void setLocY(float y){
		locY = y;
	}
	public void setLocZ(float z){
		locZ = z;
	}
	public void setRotW(float w){
		rotW = w;
	}
	public void setRotX(float x){
		rotX = x;
	}
	public void setRotY(float y){
		rotY = y;
	}
	public void setRotZ(float z){
		rotZ = z;
	}
	public string getPrefabName(){
		return prefabName;
	}
	public float getLocX(){
		return locX;
	}
	public float getLocY(){
		return locY;
	}
	public float getLocZ(){
		return locZ;
	}
	public float getRotW(){
		return rotW;
	}
	public float getRotX(){
		return rotX;
	}
	public float getRotY(){
		return rotY;
	}
	public float getRotZ(){
		return rotZ;
	}



}
