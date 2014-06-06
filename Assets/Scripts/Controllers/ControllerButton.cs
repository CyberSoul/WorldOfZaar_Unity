using UnityEngine;
using System.Collections;

public class ControllerButton : MonoBehaviour {

	public Texture textureOnPressed;
	public Texture textureOnSelected;
	public Texture textureIdle;

	private GUITexture buttonHandle;

	private bool isPressed;
	private bool isSelected;

	void OnGUI(){
	}

	// Use this for initialization
	void Start () {
		buttonHandle = (GUITexture)GetComponent (typeof(GUITexture));
		isPressed = false;
		isSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		isSelected = true;
		if (textureOnSelected) {
			buttonHandle.texture = textureOnSelected; 
		}
	}

	void OnMouseDown(){
		isPressed = true;
		if (textureOnPressed != null) {
			buttonHandle.texture = textureOnPressed; 
		}
	}

	void OnMouseUp(){
		isPressed = false;
		if (isSelected) {
			if (textureOnSelected != null) {
				buttonHandle.texture = textureOnSelected;
			}
		} else {
			if (textureIdle != null) {
				buttonHandle.texture = textureIdle;
			}
		}
	}

	void OnMouseExit(){
		isSelected = false;
		if (!isPressed && textureIdle != null) {
			buttonHandle.texture = textureIdle;		
		}
	}
}
