using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DescricaoFaseScreen : MonoBehaviour 
{
	Level.LevelScenes levelToLoad;

	public GameObject contentGo;

	void Start () 
	{
		
	}

	public void Setup(Sprite sprite, Level.LevelScenes levelToLoad)
	{
		contentGo.GetComponent<Image>().sprite = sprite;
		this.levelToLoad = levelToLoad;
		SendMessage("Show");
	}

	public void Play()
	{
		Main.instance.LoadLevel(levelToLoad);
	}


	void Update () {
	
	}
}
