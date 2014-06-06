using UnityEngine;
using System.Collections;
using LitJson;

public class deckContainer : MonoBehaviour {
	AssemblyCSharp.deck_Constructor deck_Constructor;

	// Use this for initialization
	void Start () {
		deck_Constructor = new AssemblyCSharp.deck_Constructor ();
		deck_Constructor.sendQuery ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void receiveAnswer(string jsonObject){
		deck_Constructor.JsonToObject (jsonObject);
		Debug.Log ("From deck_Container");
		Debug.Log (jsonObject);
		Debug.Log (deck_Constructor.userDecks [0].deckId);
		Debug.Log (deck_Constructor.userDecks [0].deckName);
	}
}
