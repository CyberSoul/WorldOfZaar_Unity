using UnityEngine;
using System.Collections;

public class PlayerFieldSprite : MonoBehaviour {
	
	Player player = null;
	
	public Rect limitRect = new Rect (0, 0, 128, 128);
	public float angle = 0;
	
	public int fighterCount = 3;
	public float sizeOfHeightStep = 0.5f;
	public float sizeOfHpAreaWidth = 0.125f;
	public float sizeOfHpAreaHeight = 0.5f;
	public float sizeOfTsAreaHeight = 0.33f;

	public Texture textureFighter;
	public Texture textureDeck;
	public Texture textureSupport;
	public Texture textureTalon;
	
	public int depth = 4;
	
	public GUIStyle textStyle;

	private Rect[] g_fighters;
	private Rect g_support;
	private Rect g_talon;
	private Rect g_deck;
	
	private Rect g_hp;
	private Rect g_energy;
	private Rect g_def;
	private Rect g_ts;
	private Rect g_negative;
	
	private Vector2 pivot;

//	private CardSpriteMini figter_0;

	public PlayerFieldSprite(Rect rect){
		limitRect = rect;
	}
	
	private void SetBaseSizes(){
		float tempHeight = limitRect.height * sizeOfHeightStep;
		float sizeOfOneCardEllement = (1 - 2 * sizeOfHpAreaWidth) / 3;
		
		float widthOfOneCard = limitRect.width * sizeOfOneCardEllement;
		float widthOfOnePoint = limitRect.width * sizeOfHpAreaWidth;
		
		Rect fighterRect = new Rect(limitRect.x + widthOfOneCard, limitRect.y,
		                            widthOfOneCard * 2, tempHeight);
		SetFighterSizes (fighterRect);
		g_deck = new Rect (limitRect.x, limitRect.y + tempHeight, widthOfOneCard, tempHeight );
		
		/*Rect tempPointRect = new Rect (g_deck.xMax, g_deck.yMax, widthOfOnePoint, 
		                               g_deck.height * sizeOfHpAreaHeight );*/

		g_hp = new Rect (g_deck.xMax, g_deck.yMin, widthOfOnePoint, g_deck.height * sizeOfHpAreaHeight );
		g_energy = new Rect (g_hp.xMin, g_hp.yMax, g_hp.width, g_hp.height);

		g_support = new Rect (g_hp.xMax, g_hp.yMin, g_deck.width, g_deck.height);

		g_def = new Rect (g_support.xMax, g_support.yMin, g_hp.height, g_deck.height * sizeOfTsAreaHeight);
		g_ts = new Rect (g_def.xMin, g_def.yMax, g_def.width, g_def.height);
		g_negative = new Rect (g_ts.xMin, g_ts.yMax, g_ts.width, g_ts.height);

		g_talon = new Rect (g_def.xMax, g_def.yMin, g_deck.width, g_deck.height);
		
		pivot = new Vector2(limitRect.xMin + limitRect.width * 0.5f, limitRect.yMin + limitRect.height * 0.5f);

		//figter_0 = (CardSpriteMini)(transform.FindChild ("Fighter_0"));
		/*figter_0 = (CardSpriteMini)(GameObject.Find ("Fighter_0"));
		if( figter_0 != null){
			figter_0.angle = angle;
			figter_0.limitRect = g_fighters[0];
		}*/
	}
	
	private void SetFighterSizes(Rect limitRectFighter){
		float positionX = limitRectFighter.x;
		float positionY = limitRectFighter.y;
		float widthStep = limitRectFighter.width / fighterCount;
		g_fighters = new Rect[fighterCount];
		for(int i = 0; i < fighterCount; ++i){
			g_fighters[i] = new Rect(positionX, positionY, widthStep, limitRectFighter.height);
			positionX += widthStep;
		}
	}
	
	// Use this for initialization
	void Start () {
		if(player == null){
			player = Player.TestInit();
		}
		SetBaseSizes ();
	}
	
	// Update is called once per frame
	void Update () {	
		//transform.RotateAround ( new Vector3(0.5f, 0.5f, 0f), new Vector3(1, 0, 0), 45);
	}
	
	void OnGUI() {
		if (Application.isEditor) { SetBaseSizes(); }
		GUI.depth = depth;
		Matrix4x4 matrixBackup = GUI.matrix;
		GUIUtility.RotateAroundPivot(angle, pivot);

		foreach (Rect fighter in g_fighters) {			
			GUI.DrawTexture(fighter, textureFighter);		
		}
		
		GUI.DrawTexture(g_support, textureSupport);
		GUI.DrawTexture(g_talon, textureTalon);
		GUI.DrawTexture(g_deck, textureDeck);

		
		GUI.TextArea (g_hp, player.health.ToString(), (int)g_hp.height, textStyle);
		GUI.TextArea (g_energy, player.energy.ToString(), (int)g_energy.height, textStyle);
		
		GUI.TextArea (g_def, player.defense.ToString(), (int)g_def.height, textStyle);
		GUI.TextArea (g_ts, player.mystic.ToString(), (int)g_ts.height, textStyle);
		GUI.TextArea (g_negative, player.negative.ToString(), (int)g_negative.height, textStyle);

		GUI.matrix = matrixBackup;
	}

	
	
	void OnMouseDown(){
		GameObject log = GameObject.Find ("Log");
		GUIText logText = (GUIText)log.GetComponent (typeof(GUIText));
		logText.text = "[LOG] Field " + angle;
	}
}
