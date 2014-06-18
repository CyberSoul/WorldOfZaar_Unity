using UnityEngine;
using System.Collections;

public class CardSpriteMini : MonoBehaviour {

	public int cardId = -1;
	public Card card = null;
	
	public Rect limitRect = new Rect(0, 0, 128, 128);
	public float scale = 1.0f;
	public float angle = 0;
	public float border = 0.05f;
	
	public int depth = 3;

	public GUIStyle textStyle;
	
	private Rect background;
	private Rect picture;
	private Rect iconEnergy;
	private Rect iconDef;
	private Rect iconAtack;
	private Rect iconHp;
	
	private Rect cardName;
	private Rect atack;
	private Rect def;
	private Rect hp;
	private Rect energy;
	
	private Vector2 pivot;
	
	void Start() {
		if(card == null){
			if( cardId < 4){
			card = new CardFighter ();
			} else{
				card = new Card();
			}
		}
		card.Init (cardId);
		SetBaseSizes ();
	}
	
	void OnGUI() {
		if (Application.isEditor) {
			SetBaseSizes();
		}
		
		Matrix4x4 matrixBackup = GUI.matrix;
		GUIUtility.RotateAroundPivot(angle, pivot);
		
		GUI.DrawTexture(background, card.background);
		GUI.DrawTexture(picture, card.picture);
		
		GUI.TextArea (cardName, card.name, (int)cardName.height, textStyle);
		GUI.TextArea (energy, card.energy.ToString(), (int)energy.height, textStyle);

		switch (card.cardType) {
				case CardType.Fighter:
						{
								CardFighter cardFighter = (CardFighter)card;
								GUI.DrawTexture (iconHp, cardFighter.iconHp);
								GUI.DrawTexture (iconAtack, cardFighter.iconAtack);
								GUI.DrawTexture (iconDef, cardFighter.iconDef);
			
								GUI.TextArea (atack, cardFighter.atack.ToString (), (int)atack.height, textStyle);
								GUI.TextArea (def, cardFighter.def.ToString (), (int)def.height, textStyle);
								GUI.TextArea (hp, cardFighter.hp.ToString (), (int)hp.height, textStyle);
						}
						break;
				}
		
		GUI.matrix = matrixBackup;
	}
	
	private void SetBaseSizes(){		
		background = limitRect;

		float widthWithoutBorder = limitRect.width * (1 - border * 2);
		float heightWithoutBorder = limitRect.height * (1 - border * 2);
		float offsetWithoutBorderX = limitRect.x + limitRect.width * border;
		float offsetWithoutBorderY = limitRect.y + limitRect.height * border;
		
		float ellementHeight = heightWithoutBorder / 6;
		float ellementWidth = widthWithoutBorder / 4;
		
		cardName = new Rect (offsetWithoutBorderX, offsetWithoutBorderY, widthWithoutBorder, ellementHeight );
		switch (card.cardType) {
			case CardType.Fighter:{			
				/*iconEnergy = new Rect (cardName.xMin, cardName.yMax, ellementWidth, ellementHeight);
				energy = new Rect (iconEnergy.xMax, iconEnergy.yMin, ellementWidth, ellementHeight);*/
				energy = new Rect (cardName.xMin, cardName.yMax, ellementWidth * 2, ellementHeight);

				iconHp = new Rect (energy.xMax, energy.yMin, ellementWidth, ellementHeight );
				hp = new Rect (iconHp.xMax, iconHp.yMin, iconHp.width, iconHp.height );
				
				iconDef = new Rect (energy.xMin, energy.yMax, iconHp.width, iconHp.height );
				def = new Rect (iconDef.xMax, iconDef.yMin, iconDef.width, iconDef.height );
				
				iconAtack = new Rect (def.xMax, def.yMin, iconHp.width, iconHp.height );
				atack = new Rect (iconAtack.xMax, iconAtack.yMin, iconAtack.width, iconAtack.height );
				}
			break;
		case CardType.Support:{
			//iconEnergy = new Rect (cardName.xMin, cardName.yMax, ellementWidth * 2, ellementHeight);
			//energy = new Rect (iconEnergy.xMax, iconEnergy.yMin, iconEnergy.width, iconEnergy.height);
			energy = new Rect (cardName.xMin, cardName.yMax, widthWithoutBorder, ellementHeight);

			iconHp = new Rect (energy.xMax, energy.yMin, 0, 0 );
			hp = new Rect (iconHp.xMax, iconHp.yMin, iconHp.width, iconHp.height );
			
			iconDef = new Rect (energy.xMin, energy.yMax, iconHp.width, iconHp.height );
			def = new Rect (iconDef.xMax, iconDef.yMin, iconDef.width, iconDef.height );
			
			iconAtack = new Rect (def.xMax, def.yMin, 0, 0 );
			atack = new Rect (iconAtack.xMax, iconAtack.yMin, iconAtack.width, iconAtack.height );
			}
			break;
		}

		float pictureHeight = heightWithoutBorder - cardName.height - energy.height - iconDef.height;
		picture = new Rect (iconDef.xMin, iconDef.yMax, widthWithoutBorder, pictureHeight);
		
		pivot = new Vector2(limitRect.xMin + limitRect.width * 0.5f, limitRect.yMin + limitRect.height * 0.5f);
	}
}
