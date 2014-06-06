using UnityEngine;
using System.Collections;

public class ButtonScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseUp(){
		Application.LoadLevel ("GameScene");
		return;
	}
}
