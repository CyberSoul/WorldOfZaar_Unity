using UnityEngine;
using System.Collections;

enum Race{
	HigthElf = 0,
	DarkElf,
	Veld,
	Balikuru,
	Neutral
}

public class Player{

	public int id { get; set; }

	public int health { get; set; }
	public int defense { get; set; }
	public int energy { get; set; }
	public int negative { get; set; }
	public int mystic { get; set; }

	Race race { get; set;}

	public Card[] hand;

	public Texture avatar { get; set; }

	public Player(){
		id = -1;
		health = -1;
		defense = -1;
		energy = -1;
		negative = -1;
		mystic = -1;
		race = Race.Neutral;
		hand = new Card [0];
		avatar = null;
	}

	public Player(Player player){
		id = player.id;
		health = player.health;
		defense = player.defense;
		energy = player.energy;
		negative = player.negative;
		mystic = player.mystic;

		race = player.race;
		int handLength = player.hand.Length;
		hand = new Card[handLength];
		for (int i = 0; i < handLength; ++i) {
			hand [i] = new Card (player.hand [i]);		
		}
	}

	static public Player TestInit (){
		Player res = new Player ();
		res.id = 0;
		res.health = 30;
		res.defense = 0;
		res.energy = 6;
		res.mystic = 1;
		res.negative = 0;
		res.race = Race.DarkElf;

		return res;
	}
}
