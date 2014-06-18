using UnityEngine;
using System.Collections;

public class PlayerHand : MonoBehaviour {

	public Rect limitRect = new Rect(0, 0, 700, 200);
	public int fieldsCount = 5;

	public Texture2D fieldBackground = null;

	private Rect[] fields;
	private GUITexture[] g_fields;
	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		float fieldWidth = limitRect.width / fieldsCount;
		fields = new Rect[fieldsCount];
		g_fields = new GUITexture[fieldsCount];
		GameObject field;
		for(int i = 0; i < fieldsCount; ++i){
			fields[i] = new Rect(limitRect.x + fieldWidth * i, limitRect.y, fieldWidth, limitRect.height );
		//	field = new GameObject
			//g_fields[i] = 
		}
	}

	void OnGUI(){
		for(int i = 0; i < fieldsCount; ++i){			
			GUI.DrawTexture(fields[i], fieldBackground);
		}
	}
	
	void OnMouseDown(){
		GameObject log = GameObject.Find ("Log");
		GUIText logText = (GUIText)log.GetComponent (typeof(GUIText));
		logText.text = "[LOG] Hand";
	}
}
