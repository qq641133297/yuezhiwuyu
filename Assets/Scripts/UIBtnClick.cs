using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBtnClick : MonoBehaviour {
	public CharacterCard character;
	private Image img;
	// Use this for initialization
	void Start () {
		Button seniorBtn = GameObject.Find ("Canvas/SeniorBtn").GetComponent<Button> ();
		//注册按钮的点击事件  
		seniorBtn.onClick.AddListener (delegate () {
			this.SeniorClick ();
		});
		Button commonBtn = GameObject.Find ("Canvas/CommonBtn").GetComponent<Button> ();
		//注册按钮的点击事件  
		commonBtn.onClick.AddListener (delegate () {
			this.CommonClick ();
		});
		img = GameObject.Find ("Canvas/Card").GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {
		if (img.fillAmount < 1) {
			float time = Time.deltaTime;
			img.fillAmount = img.fillAmount + time > 1 ? 1 : img.fillAmount + time;
		}
	}

	public void SeniorClick () {
		int a = Random.Range (1, 160);
		a = a == 159 ? 9999 : a % 16;
		img.fillAmount = 0f;
		character = CharacterCard.CharacterCards.Find ((x) => {
			return x.cardId == a;
		});
		GameObject.Find ("Canvas/Card/Story").GetComponent<Text> ().text = "背景：\n\n" + character.story;
		GameObject.Find ("Canvas/Card/Name").GetComponent<Text> ().text = character.name;
		GameObject.Find ("Canvas/Card/Alias").GetComponent<Text> ().text = character.alias;
		GameObject.Find ("Canvas/Card/Quality").GetComponent<Text> ().text = character.quality.ToString ();
	}
	public void CommonClick () {
		int a = Random.Range (100, 106);
		img.fillAmount = 0f;
		character = CharacterCard.CharacterCards.Find ((x) => {
			return x.cardId == a;
		});
		GameObject.Find ("Canvas/Card/Story").GetComponent<Text> ().text = "背景：\n\n" + character.story;
		GameObject.Find ("Canvas/Card/Name").GetComponent<Text> ().text = character.name;
		GameObject.Find ("Canvas/Card/Alias").GetComponent<Text> ().text = character.alias;
		GameObject.Find ("Canvas/Card/Quality").GetComponent<Text> ().text = character.quality.ToString ();
	}
}