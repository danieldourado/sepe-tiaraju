using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapLoader : MonoBehaviour 
{
	public List<Map> levelList;
	private Level.LevelScenes levelToLoad;
	void Start () 
	{
		levelToLoad = Main.instance.currentLevel;

		LoadLevel();
	}

	void LoadLevel ()
	{
		GameObject map = null;
		foreach(Map tempMap in levelList)
		{
			if(tempMap.level == levelToLoad)
			{
				map = Instantiate<GameObject>(tempMap.gameObject);
			}
		}
		map.transform.SetParent(transform);
	}

}
