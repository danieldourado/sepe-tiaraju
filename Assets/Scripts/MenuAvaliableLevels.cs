using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuAvaliableLevels : MonoBehaviour 
{
	VerticalLayoutGroup vlg;
	Score score;
	public GameObject buttonTemplate;
	// Use this for initialization
	void Start () 
	{
		vlg = GetComponent<VerticalLayoutGroup>();
		score = Main.instance.score;
		SetAvaliableLevels();
	}

	void SetAvaliableLevels ()
	{
		foreach(GameLevelRecordPoint tempLevel in score.playerData.gameRecordPoint)
		{
			CreatePlayLevelButton(tempLevel);
		}
	}

	void CreatePlayLevelButton (GameLevelRecordPoint tempLevel)
	{
		if(tempLevel.gameLevel == Level.LevelScenes.Level_1) return;

		var tempLevelButton = Instantiate<GameObject>(buttonTemplate);
		tempLevelButton.transform.SetParent(vlg.transform);

		tempLevelButton.GetComponent<Level>().level = tempLevel.gameLevel;
	
	}
}
