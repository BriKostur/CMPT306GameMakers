using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class object_info  {
	string prefabName;
	float locX;
	float locY;
	float locZ;

	float rotW;
	float rotX;
	float rotY;
	float rotZ;


	public void setName(string name){
		prefabName = name;
	}
	public void setLocX(float x){
		locX = x;
	}
	public float getLocX(){
		return locX;
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

}
