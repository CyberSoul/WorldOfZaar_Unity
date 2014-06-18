using UnityEngine;
using System.Collections;
using System;

public class ControllerMenu : MonoBehaviour {
	
	public string chatText = "чат"; 
	public string logText = "@лог";
	public string surrenderText = "@сдаться";
	public string skipText = "@пропуск";
	
	public int buttonWidth = 150;
	public int buttonHight = 54;
	
	private GameObject buttonChat;

	private float timeRaund;
	public string CheckText(string str)
	{
		string str1="";
		if(str.Length==0)return"";
		
		char aa;
		int length =  str.Length; //эта строчка нам сэкономит время.
		for(int i=0; i<length; i++)
		{
			int res=Convert.ToInt32(str[i]);
			if (res>191 && res<256)res=res+848;
			aa=Convert.ToChar(res);
			str1+=aa.ToString();
			
		}
		return str1;
	}
	
	void OnGUI(){
		/*buttonChat = GameObject.Find ("buttonChat");
		GUIText chatTxt = (GUIText)buttonChat.GetComponent(typeof(GUIText));
		chatTxt.text = CheckText(chatText);*///CheckText(chatText);

		buttonChat = GameObject.Find ("buttonTime");
		GUIText chatTxt = (GUIText)buttonChat.GetComponent(typeof(GUIText));
		chatTxt.text = ((int)( Time.time - timeRaund )).ToString();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (( Time.time - timeRaund ) > 60) {
			timeRaund = Time.time;
		}
	}
}
