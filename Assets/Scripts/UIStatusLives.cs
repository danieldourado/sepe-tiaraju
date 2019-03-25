using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIStatusLives : MonoBehaviour 
{
	Text text;
	GameData gamedata;
	void Awake()
	{
		text = GetComponent<Text>();
	}

	void Start()
	{
		gamedata = FindObjectOfType<GameData>();
	}

	void Update () 
	{
		text.text  = gamedata.lives.ToString();
	}
}
