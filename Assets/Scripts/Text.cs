using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {
	public ArrayList imageBuffer = new ArrayList();
	public static Text singleton;

	// Use this for initialization
	void Start () {

		GameObject newObj = GameObject.Find("Background");
		GUITexture guiText = (GUITexture)newObj.GetComponent(typeof(GUITexture));
		string fullFilename =@"file://C:\duelBackground.png" ;
		WWW www = new WWW(fullFilename);

		Texture2D texTmp = new Texture2D(900, 900, TextureFormat.DXT5, false);
		//LoadImageIntoTexture compresses JPGs by DXT1 and PNGs by DXT5     

		int counter = 0;
		while(! www.isDone){
			counter++;
		}

		www.LoadImageIntoTexture(texTmp);

		imageBuffer.Add(texTmp);
		guiText.texture = texTmp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		singleton = this;
		Debug.Log ("i'm here");
	}

	public void Yeah(){
		Debug.Log ("i'm here too");
	}

}
