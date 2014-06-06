using UnityEngine;
using System.Collections;

public class ControllerButtonSurrender : MonoBehaviour {
	
	void OnMouseEnter(){
		GameObject log = GameObject.Find ("Log");
		GUIText logText = (GUIText)log.GetComponent (typeof(GUIText));
		logText.text = "[LOG] text surrender moved";	
	}
	
	void OnMouseUp(){
		GameObject log = GameObject.Find ("Log");
		GUIText logText = (GUIText)log.GetComponent (typeof(GUIText));
		logText.text = "[LOG] text surrender mouseUp";
	}
	
	void OnMouseDown(){
		GameObject log = GameObject.Find ("Log");
		GUIText logText = (GUIText)log.GetComponent (typeof(GUIText));
		logText.text = "[LOG] text surrender mouseDown";
	}
	
	void OnMouseExit(){
		GameObject log = GameObject.Find ("Log");
		GUIText logText = (GUIText)log.GetComponent (typeof(GUIText));
		logText.text = "[LOG] text surrender exit";
	}
}
