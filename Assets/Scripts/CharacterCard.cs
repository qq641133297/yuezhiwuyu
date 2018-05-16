using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;
public class CharacterCard {
    public int cardId;
    public static List<CharacterCard> CharacterCards = new List<CharacterCard> ();
    public string name;
    public string alias;
    public int attack;
    public int defense;
    public string story;
    public QualityType quality;
    public enum QualityType {
        SSR = 1,
        SR = 2,
        R = 3,
        N = 4,
        Z = 5
    }
    static CharacterCard () {
        Debug.Log ("我开始构造");
        XmlDocument doc = new XmlDocument ();
        doc.Load (Application.dataPath + "/StreamingAssets/character.xml");
        XmlElement rootElem = doc.DocumentElement; //获取根节点    
        XmlNodeList personNodes = rootElem.GetElementsByTagName ("character"); //获取person子节点集合   
        Debug.Log ("开始循环" + personNodes.Count);
        foreach (XmlNode node in personNodes) {
            int id = int.Parse (((XmlElement) node).GetAttribute ("cardId")); //获取name属性值  
            XmlNodeList aliasNodes = ((XmlElement) node).GetElementsByTagName ("alias");
            string alias = aliasNodes.Count == 1 ? aliasNodes[0].InnerText : "";
            XmlNodeList nameNodes = ((XmlElement) node).GetElementsByTagName ("name");
            string name = nameNodes.Count == 1 ? nameNodes[0].InnerText : "";
            XmlNodeList storyNodes = ((XmlElement) node).GetElementsByTagName ("story");
            string story = storyNodes.Count == 1 ? storyNodes[0].InnerText : "";
            XmlNodeList attackNodes = ((XmlElement) node).GetElementsByTagName ("attack");
            int attack = int.Parse (attackNodes.Count == 1 ? attackNodes[0].InnerText : "");
            XmlNodeList defenseNodes = ((XmlElement) node).GetElementsByTagName ("defense");
            int defense = int.Parse (defenseNodes.Count == 1 ? defenseNodes[0].InnerText : "");
            XmlNodeList qualityNodes = ((XmlElement) node).GetElementsByTagName ("quality");
            string quality = qualityNodes.Count == 1 ? qualityNodes[0].InnerText : "";
            CharacterCards.Add (new CharacterCard {
                cardId = id,
                    alias = alias,
                    name = name,
                    story = story,
                    attack = attack,
                    defense = defense,
                    quality = (QualityType) Enum.Parse (typeof (QualityType), quality)
            });
        }
        Debug.Log ("构造结束");
    }
    public CharacterCard () { }
}