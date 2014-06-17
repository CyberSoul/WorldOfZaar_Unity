using UnityEngine;
using System.Collections;

public class PlayerHand : MonoBehaviour {

	public Rect limitRect = new Rect(0, 0, 700, 200);
	public int fieldsCount = 5;

	public Texture2D fieldBackground = null;

	private Rect[] g_fields;
	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		float fieldWidth = limitRect.width / fieldsCount;
		g_fields = new Rect[fieldsCount];
		for(int i = 0; i < fieldsCount; ++i){
			g_fields[i] = new Rect(limitRect.x + fieldWidth * i, limitRect.y, fieldWidth, limitRect.height );
		}
	}

	void OnGUI(){
		for(int i = 0; i < fieldsCount; ++i){			
			GUI.DrawTexture(g_fields[i], fieldBackground);
		}
	}
}
