using UnityEngine;
using System.Collections;

public class CardFighter :  Card {	
	
	public Texture2D iconDef { get; set; }
	public Texture2D iconHp { get; set; }
	public Texture2D iconAtack { get; set; }

	public int atack { get; set; }
	public int hp { get; set; }
	public int def { get; set; }


	public CardFighter(){
		background = null;
		picture = null;
		
		name = "";
		info = "";
		
		isRare = false;
		
		energy = 0;

		iconDef = null;
		iconHp = null;
		iconAtack = null;
		
		energy = 0;
		atack = 0;
		hp = 0;
		def = 0;
		
		cardType = CardType.Fighter;
	}

	public CardFighter(CardFighter card){
		background = card.background;
		picture = card.picture;
		
		name = card.name;
		info = card.info;
		
		isRare = card.isRare;
		
		energy = card.energy;
		
		iconDef = card.iconDef;
		iconHp = card.iconHp;
		iconAtack = card.iconAtack;
		
		atack = card.atack;
		hp = card.hp;
		def = card.def;

		cardType = card.cardType;
		}

	public override void Init(int id){
		base.Init (id);
		
		iconDef = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/def", typeof(Texture2D) );
		iconHp = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/hp", typeof(Texture2D) );
		iconAtack = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/atack", typeof(Texture2D) );

		switch(id){
		case 1:
			atack = 2;
			hp = 3;
			def = 0;
			break;
			
		case 2:
			atack = 1;
			hp = 8;
			def = 2;
			break;
			
		case 3:
			atack = 2;
			hp = 4;
			def = 1;
			break;
		}
	}
}
