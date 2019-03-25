using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Settings : MonoBehaviour
{

	public bool DEBUG_MODE;
	
	[HideInInspector]
	public bool IS_TOUCH_SCREEN = false;

	public enum EnemyPath
	{
		Path1,
		Path2,
		Path3
	}

	public float SELL_FACTOR = 0.7f;

	public string MAIN_MENU_SCENE = "Menu Inicial";
	public string MAIN_SCENE = "Main";
	public string GAMEPLAY_SCENE = "Gameplay";

	public Level.LevelScenes currentLevel ;
}

