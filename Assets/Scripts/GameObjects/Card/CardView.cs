using UnityEngine;
using System.Collections;

public class CardView : MonoBehaviour {
	
	public int cardId;
	public Card card;
	
	public float offsetX;
	public float offsetY;
	
	public float width;
	public float height;
	
	public float border;
	
	private GUITexture g_background;
	private GUITexture g_picture;

	private GUIText g_name;
	private GUIText g_info;
	private GUIText g_energy;
	
	private GUIText g_atack;
	private GUIText g_hp;
	private GUIText g_def;
	
	private GUITexture g_iconAtack;
	private GUITexture g_iconHp;
	private GUITexture g_iconDef;

	private Rect infoRect;

	// Use this for initialization
	void Start () {
		if(card == null){
			card = new Card ();
		}
		card.Init ();
		SetBaseSizes ();
		AplyCard ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		GUI.TextArea (infoRect, card.info, (int)infoRect.height);
	}

	private void GetBaseHandles(){
		g_background = transform.FindChild ("Background").GetComponent<GUITexture>();
		g_picture = transform.FindChild ("Picture").GetComponent<GUITexture>();
		
		g_name = transform.FindChild ("Name").GetComponent<GUIText>();
		g_info = transform.FindChild ("Info").GetComponent<GUIText>();
		g_energy = transform.FindChild ("Energy").GetComponent<GUIText>();
		
		g_atack = transform.FindChild ("atack").GetComponent<GUIText>();
		g_def = transform.FindChild ("def").GetComponent<GUIText>();
		g_hp = transform.FindChild ("hp").GetComponent<GUIText>();
		
		
		g_iconAtack = transform.FindChild ("atack").GetComponent<GUITexture>();
		g_iconDef = transform.FindChild ("def").GetComponent<GUITexture>();
		g_iconHp = transform.FindChild ("hp").GetComponent<GUITexture>();
	}
	
	private void AplyCard(){		
		g_background.texture = card.background;
		g_picture.texture = card.picture;
		
		g_name.text = card.name;
		g_info.text = card.info;
		g_energy.text = card.energy.ToString();
		
		g_atack.text = card.atack.ToString();
		g_def.text = card.def.ToString();
		g_hp.text = card.hp.ToString();
		
		g_iconHp.texture = card.iconHp;
		g_iconAtack.texture = card.iconAtack;
		g_iconDef.texture = card.iconDef;
	}
	
	private void SetBaseSizes(){
		GetBaseHandles ();

		g_background.pixelInset = new Rect (offsetX, offsetY, width, height);
		
		float widthWithoutBorder = width * (1 - border * 2);
		float heightWithoutBorder = height * (1 - border * 2);
		float offsetWithoutBorderX = offsetX + width * border;
		float offsetWithoutBorderY = offsetY + height * border;
		
		float ellementHeight = heightWithoutBorder / 12;
		float ellementWidth = widthWithoutBorder / 6;
		
		float printOffsetX = ellementWidth / 2;
		float printOffsetY = ellementHeight / 2;	

		g_energy.pixelOffset = new Vector2 ( offsetWithoutBorderX + printOffsetX,
		                                    offsetWithoutBorderY + ellementHeight * 11 + printOffsetY );
		printOffsetX = ellementWidth * 5 / 2;
		g_name.pixelOffset = new Vector2 (offsetWithoutBorderX + ellementWidth + printOffsetX, 
		                               offsetWithoutBorderY + ellementHeight * 11 + printOffsetY);

		printOffsetX = ellementWidth / 2;
		g_atack.pixelOffset = new Vector2 ( offsetWithoutBorderX + ellementWidth + printOffsetX, 
		                                   offsetWithoutBorderY + ellementHeight * 10 + printOffsetY );
		g_def.pixelOffset = new Vector2 ( offsetWithoutBorderX + + ellementWidth * 3+ printOffsetX,
		                                 offsetWithoutBorderY + ellementHeight * 10 + printOffsetY );
		g_hp.pixelOffset = new Vector2 ( offsetWithoutBorderX + ellementWidth * 5 + printOffsetX,
		                                offsetWithoutBorderY + ellementHeight * 10 + printOffsetY );
		
		
		g_iconAtack.pixelInset = new Rect ( offsetWithoutBorderX,
		                                   offsetWithoutBorderY + ellementHeight * 10,
		                                   ellementWidth, ellementHeight );
		g_iconDef.pixelInset = new Rect ( offsetWithoutBorderX + ellementWidth * 2, 
		                                 offsetWithoutBorderY + ellementHeight * 10, 
		                                 ellementWidth, ellementHeight );
		g_iconHp.pixelInset = new Rect ( offsetWithoutBorderX + ellementWidth * 4,
		                                offsetWithoutBorderY + ellementHeight * 10,
		                                ellementWidth, ellementHeight );
		
		g_picture.pixelInset = new Rect (offsetWithoutBorderX , offsetWithoutBorderY + ellementHeight * 5, 
		                                 widthWithoutBorder, ellementHeight * 5);

		infoRect = new Rect (offsetWithoutBorderX, Screen.width - (offsetWithoutBorderY + ellementHeight * 5),
		                    widthWithoutBorder, ellementHeight * 5);
		//g_info.pixelOffset = new Vector2()
	}
}
