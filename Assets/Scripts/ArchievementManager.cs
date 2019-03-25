using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArchievementManager : MonoBehaviour 
{
	public List<GameObject> archievements;
	
	// Use this for initialization
	void Start () 
	{
		RemoveUsedArchievements();
	}

	void RemoveUsedArchievements ()
	{
		var usedArchievements = Main.instance.score.playerData.archievementBadges;

		List<GameObject> treeList = new List<GameObject>();

		foreach(int tempID in usedArchievements)
		{
			foreach(GameObject tempArchievement in archievements)
			{
				ArchievementBadge tempBadge = tempArchievement.GetComponent<ArchievementBadge>();
				if(tempBadge.badgeID == tempID)
					treeList.Add(tempArchievement);
			}
		}

		foreach(GameObject tempGo in treeList)
		{
			archievements.Remove(tempGo);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		var playerData = Main.instance.score.playerData;
		foreach(GameObject tempArchievement in archievements)
		{
			Statistics tempStatistics = tempArchievement.GetComponent<Statistics>();
			
			if(tempStatistics.builtTowers > 0)
			{
				if(playerData.progressData.builtTowers >= tempStatistics.builtTowers)
					SetArchievementConquered(tempStatistics.gameObject);
			}
			
			if(tempStatistics.kills > 0)
			{
				if(playerData.progressData.kills >= tempStatistics.kills)
					SetArchievementConquered(tempStatistics.gameObject);
			}
			
			if(tempStatistics.specialHability1 > 0)
			{
				if(playerData.progressData.specialHability1 >= tempStatistics.specialHability1)
					SetArchievementConquered(tempStatistics.gameObject);
			}
			
			if(tempStatistics.specialHability2 > 0)
			{
				if(playerData.progressData.specialHability2 >= tempStatistics.specialHability2)
					SetArchievementConquered(tempStatistics.gameObject);
			}
			
			if(tempStatistics.specialHability3 > 0)
			{
				if(playerData.progressData.specialHability3 >= tempStatistics.specialHability3)
					SetArchievementConquered(tempStatistics.gameObject);
			}
			
			if(tempStatistics.stars > 0)
			{
				if(playerData.progressData.stars >= tempStatistics.stars)
					SetArchievementConquered(tempStatistics.gameObject);
			}
			
			if(tempStatistics.towersSold > 0)
			{
				if(playerData.progressData.towersSold >= tempStatistics.towersSold)
					SetArchievementConquered(tempStatistics.gameObject);
			}
			
			if(tempStatistics.upgradedTowerLevel3 > 0)
			{
				if(playerData.progressData.upgradedTowerLevel3 >= tempStatistics.upgradedTowerLevel3)
					SetArchievementConquered(tempStatistics.gameObject);
			}
			
			if(tempStatistics.wavesCalledEarly > 0)
			{
				if(playerData.progressData.wavesCalledEarly >= tempStatistics.wavesCalledEarly)
					SetArchievementConquered(tempStatistics.gameObject);
			}
			
			if(tempStatistics.wonEveryLevel)
			{
				if(playerData.progressData.wonEveryLevel)
					SetArchievementConquered(tempStatistics.gameObject);
			}
			
			if(tempStatistics.killedGiantEnemy)
			{
				if(playerData.progressData.killedGiantEnemy)
					SetArchievementConquered(tempStatistics.gameObject);
			}
		}
	
	}

	void SetArchievementConquered (GameObject gameObject)
	{
		GameObject archievement = Instantiate<GameObject>(gameObject);
		var ab = archievement.GetComponent<ArchievementBadge>();

		Main.instance.score.AddArchievementBadge(ab);

		Main.instance.audioManager.PlayAudio(Main.instance.sounds.conquistaGanha);

		ab.Show();

		RemoveUsedArchievements();


		
	}
}
