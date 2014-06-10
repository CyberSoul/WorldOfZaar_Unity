using UnityEngine;
using System.Collections;

public class Card{

	public Texture2D background { get; set; }
	public Texture2D picture { get; set; }

	public string name { get; set; }
	public string info { get; set; }

	public bool isRare { get; set; }

	public Texture2D iconDef { get; set; }
	public Texture2D iconHp { get; set; }
	public Texture2D iconAtack { get; set; }

	public int energy { get; set; }
	public int atack { get; set; }
	public int hp { get; set; }
	public int def { get; set; }

	public Color backgroundColor { get; set; }
	public Color textColor { get; set; }

	public Card(){
		background = null;
		picture = null;

		name = "";
		info = "";

		isRare = false;

		iconDef = null;
		iconHp = null;
		iconAtack = null;

		energy = 0;
		atack = 0;
		hp = 0;
		def = 0;

		backgroundColor = new Color (256, 256, 256);
		textColor = new Color (0, 0, 0);
	}

	public Card(Card card){
		background = card.background;
		picture = card.picture;
		
		name = card.name;
		info = card.info;
		
		isRare = card.isRare;
		
		iconDef = card.iconDef ;
		iconHp = card.iconHp;
		iconAtack = card.iconAtack;
		
		energy = card.energy;
		atack = card.atack;
		hp = card.hp;
		def = card.def;
		
		backgroundColor = card.backgroundColor;
		textColor = card.textColor;
	}

	public void Init(){
		background = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/_TE", typeof(Texture2D) );
		picture = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/Rokirovaka_support_VE", typeof(Texture2D) );
		
		name = "Name";
		info = "Info\nSome info\nmore info/....";
		
		isRare = false;
		
		iconDef = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/def", typeof(Texture2D) );
		iconHp = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/hp", typeof(Texture2D) );
		iconAtack = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/atack", typeof(Texture2D) );
		
		energy = 1;
		atack = 2;
		hp = 4;
		def = 3;
		
		backgroundColor = new Color (256, 256, 256);
		textColor = new Color (0, 0, 0);			
	}
}
