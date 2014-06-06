using UnityEngine;
using System.Collections;

public class TabButton_Animation : MonoBehaviour {
	
	public string tabName = "";
	public bool isActive = false;
	private ArrayList imageBuffer = new ArrayList();
	GUITexture buttonGUI;

	// Use this for initialization
	void Start () {
		GameObject button = GameObject.Find(tabName+"_TabButton");
		buttonGUI = (GUITexture)button.GetComponent(typeof(GUITexture));

		Texture2D texture_hower = (Texture2D) Resources.Load ("Images/NavigationBar/Lables/"+tabName+"Hower", typeof(Texture2D));

		imageBuffer.Add(buttonGUI.texture);
		imageBuffer.Add(texture_hower);
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

	void OnMouseUp(){
		Application.LoadLevel (tabName);
	}
}
