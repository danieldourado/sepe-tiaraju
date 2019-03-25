﻿using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour 
{
	public enum LevelScenes
	{
		Level_1,
		Level_2,
		Level_3,
		Level_4,
		Level_5,
		Level_6,
		Level_7,
		Level_8,
		Level_9,
		Level_10,
		Level_11,
		Level_12,
		Level_13,
		Level_14,
		Level_15,
		Level_16
	}

	public LevelScenes level;

	void Start () 
	{
	
	}
	
	public void LoadLevel () 
	{
		Main.instance.sceneLoader.LoadSceneAsync(Main.instance.settings.GAMEPLAY_SCENE);
	}
}


