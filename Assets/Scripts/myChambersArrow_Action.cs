using UnityEngine;
using System.Collections;

public class myChambersArrow_Action : MonoBehaviour {

	public string arrowName ="";
	public int direction;

	private ArrayList imageBuffer = new ArrayList();
	GUITexture buttonGUI;
	
	// Use this for initialization
	void Start () {
		GameObject button = GameObject.Find(arrowName+"_Arrow");
		buttonGUI = (GUITexture)button.GetComponent(typeof(GUITexture));
	
		Texture2D texture_hower = (Texture2D) Resources.Load ("Images/MyChambers/NavigationArrows/"+arrowName+"Hower", typeof(Texture2D));
		Texture2D texture_click = (Texture2D) Resources.Load ("Images/MyChambers/NavigationArrows/"+arrowName+"Click", typeof(Texture2D));

		imageBuffer.Add(buttonGUI.texture);
		imageBuffer.Add(texture_hower);
		imageBuffer.Add(texture_click);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		buttonGUI.texture = (Texture2D) imageBuffer [1];
	}
	
	void OnMouseExit(){
		buttonGUI.texture = (Texture2D) imageBuffer [0];
	}

	void OnMouseDown(){
		buttonGUI.texture = (Texture2D) imageBuffer [2];

	}
	void OnMouseUp(){
		buttonGUI.texture = (Texture2D) imageBuffer [1];
	}
}
