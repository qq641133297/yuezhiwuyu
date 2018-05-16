using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
	public CharacterCard character;
	// Use this for initialization
	void Awake () {
		int a = Random.Range (1, 13);
		character = CharacterCard.CharacterCards.Find ((x) => {
			return x.cardId == a;
		});
		Debug.Log (character.name);
		GameObject.Find ("Canvas/Card/Name").GetComponent<Text> ().text = character.name;
		GameObject.Find ("Canvas/Card/Alias").GetComponent<Text> ().text = character.alias;
		GameObject.Find ("Canvas/Card/Quality").GetComponent<Text> ().text = character.quality.ToString();
	}

	// Update is called once per frame
	void Update () {

	}
}