using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HallDoHeroiBtnSelectHero : MonoBehaviour 
{
	public Hero.HeroID heroID;
	public Sprite heroSprite;
	public Sprite atributosSprite;
	public InfoData heroInfo;


	void Start () 
	{
		
	}
	
	// Update is called once per frame
	public void OnClick () 
	{
		Main.instance.score.playerData.currentHero = heroID;
		GameObject.FindGameObjectWithTag("HallDoHeroiHeroImage").GetComponent<Image>().sprite = heroSprite;
		GameObject.FindGameObjectWithTag("HallDoHeroiHeroAtributos").GetComponent<Image>().sprite = atributosSprite;
		GameObject.FindGameObjectWithTag("HallDoHeroiHeroTitulo").GetComponent<Text>().text = heroInfo.name;
		GameObject.FindGameObjectWithTag("HallDoHeroiHeroDescricao").GetComponent<Text>().text = heroInfo.description;
	}
}
