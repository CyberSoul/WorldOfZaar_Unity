using UnityEngine;
using System.Collections;

public enum CardType{
	None = -1,
	Support = 0,
	Fighter
};

public class Card{
	public Texture2D background { get; set; }
	public Texture2D picture { get; set; }

	public string name { get; set; }
	public string info { get; set; }

	public bool isRare { get; set; }

	public int energy { get; set; }

	public CardType cardType  { get; set; }

	public Card(){
		background = null;
		picture = null;

		name = "";
		info = "";

		isRare = false;

		energy = 0;

		cardType = CardType.Support;
	}

	public Card(Card card){
		background = card.background;
		picture = card.picture;
		
		name = card.name;
		info = card.info;
		
		isRare = card.isRare;
		
		energy = card.energy;

		cardType = card.cardType;
	}

	public virtual void Init( int id ){
		switch( id ){
		case 1:
			background = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/_TE", typeof(Texture2D) );
			picture = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/CardPicture/SpiderFighter", typeof(Texture2D) );
			
			name = "Fighter";
			info = "";
			
			isRare = false;
			
			energy = 1;
			break;
			
		case 2:
			background = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/_TE", typeof(Texture2D) );
			picture = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/CardPicture/SpiderGuardian", typeof(Texture2D) );
			
			name = "Guardian";
			info = "";
			
			isRare = false;
			
			energy = 4;
			break;
			
		case 3:
			background = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/_TE", typeof(Texture2D) );
			picture = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/CardPicture/CatacombFighter", typeof(Texture2D) );
			
			name = "Catacomber";
			info = "";
			
			isRare = false;
			
			energy = 2;
			break;
			
		case 4:
			background = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/_TE", typeof(Texture2D) );
			picture = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/CardPicture/CoccoonSupport", typeof(Texture2D) );
			
			name = "Coccoon";
			info = "Safe from attack";
			
			isRare = false;
			
			energy = 2;
			break;
			
		case 5:
			background = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/_TE", typeof(Texture2D) );
			picture = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/CardPicture/whipSupport", typeof(Texture2D) );
			
			name = "Whip";
			info = "Deal 1 damage.";
			
			isRare = false;
			
			energy = 1;
			break;
		}
	}
}
