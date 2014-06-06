using UnityEngine;
using System.Collections;


public class authorizationScript : MonoBehaviour {
	public string login = "";
	public string pass = "";

	void OnGUI() {
		login = GUI.TextField(new Rect(365, 330, 200, 20), login, 25);
		pass = GUI.TextField(new Rect(365, 420, 200, 20), pass, 25);

		if (GUI.Button (new Rect (365, 520, 200, 20), "Enter world")) {
			Application.ExternalCall( "authorization", "email="+login+"&password="+pass );
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void loginState(string data){
		if (data.Contains ("true") || data.Contains ("True") || data.Contains ("TRUE")) {
			Application.LoadLevel("myChambers");		
			return;
		}
	}

}
