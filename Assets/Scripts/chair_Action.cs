using UnityEngine;
using System.Collections;

public class chair_Action : MonoBehaviour {

	public string chair_ID = "";
	private ArrayList imageBuffer = new ArrayList();
	private bool isAvailible;
	GUITexture buttonGUI;

	// Use this for initialization
	void Start () {
		GameObject button = GameObject.Find(chair_ID);
		buttonGUI = (GUITexture)button.GetComponent(typeof(GUITexture));

		Texture2D texture_hower = (Texture2D) Resources.Load ("Images/Duel/Sits/chairHower", typeof(Texture2D));

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
}
