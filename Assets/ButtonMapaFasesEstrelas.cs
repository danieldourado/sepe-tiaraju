using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class ButtonMapaFasesEstrelas : MonoBehaviour 
{
	public Sprite starSprite;
	public GameObject star1,star2,star3;

	// Use this for initialization
	void Start () 
	{
		//SetVisibility();
		SetScore();
	}

	void SetVisibility ()
	{
		var levels = Main.instance.score.playerData.gameRecordPoint;
		var currentLevel = GetComponent<Level>().level;
		var currentLevelNumber = GetLevelNumber(currentLevel);

		if(currentLevelNumber == 1) return;

		if(levels.Count+1 > currentLevelNumber)
			return;

		foreach(GameLevelRecordPoint tempLevel in levels)
		{
			var tempLevelNumber = GetLevelNumber(tempLevel.gameLevel);

			if(tempLevelNumber <= currentLevelNumber+1)
			{
				return;
			}
		}

		gameObject.SetActive(false);
	}

	void SetScore ()
	{
		if(gameObject.activeSelf == false ) return;

		var levels = Main.instance.score.playerData.gameRecordPoint;
		var currentLevel = GetComponent<Level>().level;
		GameLevelRecordPoint level = levels.FirstOrDefault(lvl => lvl.gameLevel == currentLevel);

		if(level == null) return;
		if(levels.Count == 0) return;


		if(level.maxScoreStars >= 1)
			star1.GetComponent<Image>().overrideSprite = starSprite;
		if(level.maxScoreStars >= 2)
			star2.GetComponent<Image>().overrideSprite = starSprite;
		if(level.maxScoreStars >= 3)
			star3.GetComponent<Image>().overrideSprite = starSprite;
	}

	int GetLevelNumber(Level.LevelScenes level)
	{
		return int.Parse(level.ToString().Substring(level.ToString().Length-1,1));
	}
}
