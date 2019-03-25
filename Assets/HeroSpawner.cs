using UnityEngine;
using System.Collections;

public class HeroSpawner : MonoBehaviour 
{
	Hero.HeroID heroToSpawn;
	GameObject heroPrefab;
	void Start () 
	{
		heroToSpawn = Main.instance.score.playerData.currentHero;
		var heroList = FindObjectOfType<HeroList>().heroList;
		foreach(GameObject tempGO in heroList)
		{
			Hero.HeroID tempId = tempGO.GetComponent<Hero>().heroID;
			if(tempId == heroToSpawn)
			{
				AllyDuel allyScript = Instantiate<GameObject>(tempGO).GetComponent<AllyDuel>();
				allyScript.transform.position = transform.position;
				allyScript.SetAsReinforcementWarrior(transform.position);
				return;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
