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

	public virtual void Init(){
		background = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/_TE", typeof(Texture2D) );
		picture = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/Rokirovaka_support_VE", typeof(Texture2D) );
		
		name = "Name";
		info = "Info\nSome info\nmore info/....";
		
		isRare = false;
		
		energy = 1;
	}
}
