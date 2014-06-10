using UnityEngine;
using System.Collections;

public class CardSprite : MonoBehaviour {
	
	public int cardId = -1;
	public Card card = null;

	public Rect limitRect = new Rect(0, 0, 128, 128);
	public float scale = 1.0f;
	public float angle = 0;
	public float border = 0.05f;
	
	public int depth = 3;

	public GUIStyle textStyle;
	public GUIStyle infoStyle;

	private Rect background;
	private Rect picture;
	private Rect iconDef;
	private Rect iconAtack;
	private Rect iconHp;

	private Rect cardName;
	private Rect atack;
	private Rect def;
	private Rect hp;
	private Rect energy;
	private Rect info;

	private Vector2 pivot;
	
	void Start() {
		if(card == null){
			card = new CardFighter ();
		}
		card.Init ();
		SetBaseSizes ();
	}
		
	void OnGUI() {
		if (Application.isEditor) {
			SetBaseSizes();
		}
		GUI.depth = depth;

		Matrix4x4 matrixBackup = GUI.matrix;
		GUIUtility.RotateAroundPivot(angle, pivot);

		GUI.DrawTexture(background, card.background);
		GUI.DrawTexture(picture, card.picture);
		
		GUI.TextArea (cardName, card.name, (int)cardName.height, textStyle);
		GUI.TextArea (energy, card.energy.ToString(), (int)energy.height, textStyle);

		switch (card.cardType) {
			case (CardType.Support):{
			}
			break;
			case CardType.Fighter:{
				CardFighter cardFighter = (CardFighter)card;
						
				GUI.DrawTexture(iconHp, cardFighter.iconHp);
				GUI.DrawTexture(iconAtack, cardFighter.iconAtack);
				GUI.DrawTexture(iconDef, cardFighter.iconDef);

				GUI.TextArea (atack, cardFighter.atack.ToString(), (int)atack.height, textStyle);
				GUI.TextArea (def, cardFighter.def.ToString(), (int)def.height, textStyle);
				GUI.TextArea (hp, cardFighter.hp.ToString(), (int)hp.height, textStyle);
			}
			break;
		}
		GUI.TextArea (info, card.info, (int)info.height, infoStyle);

		GUI.matrix = matrixBackup;
	}
	
	private void SetBaseSizes(){		
		background = limitRect;
		
		float widthWithoutBorder = limitRect.width * (1 - border * 2);
		float heightWithoutBorder = limitRect.height * (1 - border * 2);
		float offsetWithoutBorderX = limitRect.x + limitRect.width * border;
		float offsetWithoutBorderY = limitRect.y + limitRect.height * border;
		
		float ellementHeight = heightWithoutBorder / 12;
		float ellementWidth = widthWithoutBorder / 6;
		
		cardName = new Rect (offsetWithoutBorderX, offsetWithoutBorderY, widthWithoutBorder - ellementWidth, ellementHeight );
		energy = new Rect (cardName.xMax, cardName.yMin, ellementWidth, cardName.height);

		switch (card.cardType) {
			case (CardType.Support):{
				iconHp = new Rect (cardName.xMin, cardName.yMax, 0, 0 );
				
			}
			break;
			case CardType.Fighter:
			{
				iconHp = new Rect (cardName.xMin, cardName.yMax, ellementWidth, ellementHeight );
			}
			break;
		}
		hp = new Rect (iconHp.xMax, iconHp.yMin, iconHp.width, iconHp.height );
		
		iconDef = new Rect (hp.xMax, hp.yMin, iconHp.width, iconHp.height );
		def = new Rect (iconDef.xMax, iconDef.yMin, iconHp.width, iconHp.height );
		
		iconAtack = new Rect (def.xMax, def.yMin, iconHp.width, iconHp.height );
		atack = new Rect (iconAtack.xMax, iconAtack.yMin, iconHp.width, iconHp.height );
		
		picture = new Rect (iconHp.xMin, iconHp.yMax, widthWithoutBorder, ellementHeight * 5);

		float infoHeight = heightWithoutBorder - picture.height - hp.height - cardName.height;
		info = new Rect (picture.xMin, picture.yMax, widthWithoutBorder, infoHeight);

		pivot = new Vector2(limitRect.xMin + limitRect.width * 0.5f, limitRect.yMin + limitRect.height * 0.5f);
	}
}
