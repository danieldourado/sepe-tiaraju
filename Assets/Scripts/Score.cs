using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Score : MonoBehaviour
{
	public int currentScoreStars;
	public bool isRecord;

	public PlayerData playerData;

	private string FILE_NAME = "playerInfo.dat";

	void Awake()
	{
		Load();
	}
	
	public void AddScore(int ammount)
	{
		currentScoreStars += ammount;
		playerData.ammountOfStars += ammount;
		playerData.progressData.stars += ammount;
		UpdateScore();
	}

	public void AddArchievementBadge(ArchievementBadge ab)
	{
		playerData.archievementBadges.Add(ab.badgeID);
		Save ();
	}


	private void UpdateScore()
	{
		bool objectExists = false;
		foreach(GameLevelRecordPoint tempGameLevelRecordPoint in playerData.gameRecordPoint)
		{
			if(tempGameLevelRecordPoint.gameLevel == Main.instance.settings.currentLevel)
			{
				objectExists = true;
				if(currentScoreStars > tempGameLevelRecordPoint.maxScoreStars)
				{
					tempGameLevelRecordPoint.maxScoreStars = currentScoreStars;
					isRecord = true;
				}
				else
				{
					isRecord = false;
				}
			}
		}
		if(objectExists == false)
		{
			GameLevelRecordPoint newGameRecordPoint = new GameLevelRecordPoint();
			newGameRecordPoint.gameLevel = Main.instance.settings.currentLevel;
			newGameRecordPoint.maxScoreStars = currentScoreStars;
			playerData.gameRecordPoint.Add(newGameRecordPoint);
		}
		Save ();
	}

	void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/"+FILE_NAME);

		bf.Serialize(file, playerData);
		file.Close();
	}

	void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/"+FILE_NAME))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/"+FILE_NAME, FileMode.Open);
			PlayerData data = (PlayerData) bf.Deserialize(file);
			file.Close();

			playerData = data;
		}
		else
		{
			playerData = new PlayerData();
		}
	}

	void ResetCurrentScore ()
	{
		currentScoreStars = 0;
	}

	public int GetMaxScore()
	{
		foreach(GameLevelRecordPoint tempGameLevelRecordPoint in playerData.gameRecordPoint)
		{
			if(tempGameLevelRecordPoint.gameLevel == Main.instance.settings.currentLevel)
			{
				return tempGameLevelRecordPoint.maxScoreStars;
			}
		}
		return 0;
	}

	//UPGRADES*****

	public void AddUpgrade(UpgradeVO upgrade)
	{
		playerData.allUpgrades.Add(upgrade); 

		UpgradeVO upgradeToBeDeleted = null;
		foreach(UpgradeVO existingUpgrade in playerData.currentUpgrades)
		{
			if(existingUpgrade.type == upgrade.type)
			{
				upgradeToBeDeleted = existingUpgrade;
			}
		}

		if(upgradeToBeDeleted != null)
		{
			playerData.currentUpgrades.Remove(upgradeToBeDeleted);
		}

		playerData.currentUpgrades.Add(upgrade);
		AddScore(upgrade.price *-1);
		Save();
	}

	public int GetUpgradeLevel(Upgrade.UpgradeType type)
	{
		var upgrades = Main.instance.score.playerData.currentUpgrades;
		foreach(UpgradeVO currentUpgrade in upgrades)
		{
			if(currentUpgrade.type == type)
			{
				return currentUpgrade.level;
			}
		}
		return 0;
	}

	public void ResetUpgrades()
	{
		foreach(UpgradeVO tempUpgrade in playerData.allUpgrades)
		{
			AddScore(tempUpgrade.price);
		}

		playerData.allUpgrades = new List<UpgradeVO>();
		playerData.currentUpgrades = new List<UpgradeVO>();
		Save();
	}

}
[Serializable]
public class PlayerData
{
	public int ammountOfStars;
	public List<GameLevelRecordPoint> gameRecordPoint = new List<GameLevelRecordPoint>();
	public List<int> archievementBadges = new List<int>();
	public StatisticsNMB progressData = new StatisticsNMB();
	public Hero.HeroID currentHero = Hero.HeroID.sepeLvl1;
	public List<UpgradeVO> currentUpgrades = new List<UpgradeVO>();
	public List<UpgradeVO> allUpgrades = new List<UpgradeVO>();


}

[Serializable]
public class GameLevelRecordPoint
{
	public Level.LevelScenes gameLevel;
	public int maxScoreStars;
}
