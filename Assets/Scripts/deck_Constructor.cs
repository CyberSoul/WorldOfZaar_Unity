//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34003
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using LitJson;
using UnityEngine;

namespace AssemblyCSharp
{
	public class deck_Constructor
	{
		public Deck[] userDecks;

		public deck_Constructor ()
		{
		}

		public void sendQuery(){
			Application.ExternalCall( "getUserDecks","");
		}
		public void JsonToObject(string json)
		{
			userDecks = (Deck[])JsonMapper.ToObject<Deck[]>(json);
		}
	}
}
