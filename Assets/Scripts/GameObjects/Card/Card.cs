using UnityEngine;
using System.Collections;

public class Card{

	public Texture2D background;
	public Texture2D picture;

	public string name;
	public string info;

	public bool isRare;

	public Texture2D iconDef;
	public Texture2D iconHp;
	public Texture2D iconAtack;

	public int energy;
	public int atack;
	public int hp;
	public int def;

	public Color backgroundColor;
	public Color textColor;

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

	public void Init(){
		background = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/_TE", typeof(Texture2D) );
		picture = (Texture2D)Resources.Load ("Images/GameState/Symbols/Card/Rokirovaka_support_VE", typeof(Texture2D) );
		
		name = "Name";
		info = "Info/nSome info/nmore info/....";
		
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
