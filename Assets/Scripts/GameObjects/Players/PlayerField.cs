using UnityEngine;
using System.Collections;

public class PlayerField : MonoBehaviour {

	Player player;

	public Rect limitRect;

	public int fighterCount;
	public float sizeOfHeightStep;
	public float sizeOfHpAreaWidth;
	public float sizeOfHpAreaHeight;
	public float sizeOfTsAreaHeight;

	private GUITexture[] g_fighter;
	private GUITexture g_support;
	private GUITexture g_talon;
	private GUITexture g_deck;
	
	private GUIText g_hp;
	private GUIText g_energy;
	private GUIText g_def;
	private GUIText g_ts;
	private GUIText g_negative;
	
	public PlayerField(Rect rect){
		limitRect = rect;
	}
	
	private void GetAllHandles(){
		g_fighter = new GUITexture[fighterCount];
		for( int i = 0; i < fighterCount; ++i){
			g_fighter[i] = transform.FindChild("fighterField_"+i).GetComponent<GUITexture>();
		}
		g_support = transform.FindChild("supportField").GetComponent<GUITexture>();
		g_talon = transform.FindChild("talonField").GetComponent<GUITexture>();
		g_deck = transform.FindChild("deckField").GetComponent<GUITexture>();
		
		g_hp = transform.FindChild("hpField").GetComponent<GUIText>();
		g_energy = transform.FindChild("energyField").GetComponent<GUIText>();
		g_ts = transform.FindChild("tsField").GetComponent<GUIText>();
		g_def = transform.FindChild("defField").GetComponent<GUIText>();
		g_negative = transform.FindChild("negativeField").GetComponent<GUIText>();
	}
	
	private void SetBaseSizes(){
		GetAllHandles ();
		float tempHeight = limitRect.height * sizeOfHeightStep;
		float sizeOfOneCardEllement = (1 - 2 * sizeOfHpAreaWidth) / 3;

		float widthOfOneCard = limitRect.width * sizeOfOneCardEllement;
		float widthOfOnePoint = limitRect.width * sizeOfHpAreaWidth;

		Rect fighterRect = new Rect(limitRect.x + widthOfOneCard, limitRect.y,
		                            widthOfOneCard * 2, tempHeight);
		SetFighterSizes (fighterRect);
		Rect tempCardRect = new Rect (limitRect.x, limitRect.y - tempHeight, widthOfOneCard, tempHeight );
		g_deck.pixelInset = tempCardRect;

		Rect previousRect = g_deck.pixelInset;

		Rect tempPointRect = new Rect (previousRect.xMax, previousRect.yMax, widthOfOnePoint, 
		                               previousRect.height * sizeOfHpAreaHeight );
		g_hp.pixelOffset = new Vector2 (tempPointRect.x + tempPointRect.width / 2, 
		                                tempPointRect.y - tempPointRect.height / 2);
		g_energy.pixelOffset = new Vector2 (tempPointRect.x + tempPointRect.width / 2, 
		                                    tempPointRect.y - tempPointRect.height / 2 - tempPointRect.height );

		tempCardRect.x = tempPointRect.xMax;
		g_support.pixelInset = tempCardRect;

		tempPointRect.x = tempCardRect.xMax;
		tempPointRect.height = tempCardRect.height * sizeOfTsAreaHeight;
		g_def.pixelOffset = new Vector2 (tempPointRect.x + tempPointRect.width / 2,
		                                 tempPointRect.y - tempPointRect.height / 2);
		g_ts.pixelOffset = new Vector2 (tempPointRect.x + tempPointRect.width / 2,
		                                 tempPointRect.y - tempPointRect.height / 2 - tempPointRect.height );
		g_negative.pixelOffset = new Vector2 (tempPointRect.x + tempPointRect.width / 2,
		                                 tempPointRect.y - tempPointRect.height / 2 - tempPointRect.height * 2 );

		tempCardRect.x = tempPointRect.xMax;
		g_talon.pixelInset = tempCardRect;

		//g_talon.transform.Rotate (Vector3.right, 90);
		Vector3 angles = g_talon.transform.eulerAngles;
		
		GameObject log = GameObject.Find ("Log");
		GUIText logText = (GUIText)log.GetComponent (typeof(GUIText));
		logText.text = "[LOG] angles{"+angles.x+", "+angles.y+", "+angles.z+"}";	
		angles.x += 90;
		g_talon.transform.Rotate (Vector3.left * -90);
		//g_talon.transform.Translate(new Vector3(20.0f, 20.0f, 20.0f));
		angles = g_talon.transform.eulerAngles;

		logText = (GUIText)log.GetComponent (typeof(GUIText));
		logText.text += "\n[LOG] angles{"+angles.x+", "+angles.y+", "+angles.z+"}";
	}

	private void SetFighterSizes(Rect limitRectFighter){
		float positionX = limitRectFighter.x;
		float positionY = limitRectFighter.y;
		float widthStep = limitRectFighter.width / fighterCount;
		for(int i = 0; i < fighterCount; ++i){
			g_fighter[i].pixelInset = new Rect(positionX, positionY, widthStep, limitRectFighter.height);
			positionX += widthStep;
		}
	}
	
	// Use this for initialization
	void Start () {
		SetBaseSizes ();
	}
	
	// Update is called once per frame
	void Update () {	
		//transform.RotateAround ( new Vector3(0.5f, 0.5f, 0f), new Vector3(1, 0, 0), 45);
	}

	void onGUI(){
		Texture2D background = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/_TE", typeof(Texture2D) );

		GUI.BeginGroup (new Rect(limitRect));
		GUIUtility.RotateAroundPivot (5, new Vector2 (limitRect.width / 2, limitRect.height / 2));
		GUI.DrawTexture (limitRect, background);
		GUI.EndGroup ();
	}
}
