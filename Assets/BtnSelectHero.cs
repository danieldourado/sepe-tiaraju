using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnSelectHero : MonoBehaviour 
{

	private Hero hero;
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(hero == null)
		{
			hero = FindObjectOfType<Hero>();
			if(hero == null) return;
			GetComponent<Image>().sprite = hero.heroSprite;
		}
	}
}
