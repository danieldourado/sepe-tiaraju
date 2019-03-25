using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour 
{
	Waves waves;
	ObjectPool pool;
	GameData gameData;

	void Start () 
	{
		Invoke("GetObjs", 1f);
	}

	public void GetObjs()
	{
		waves = FindObjectOfType<Waves>();
		pool = FindObjectOfType<ObjectPool>();
		gameData = FindObjectOfType<GameData>();
	}
	
	void Update () 
	{
		if(waves == null) return;

		CheckWin();
		CheckLose();

	}

	void CheckWin ()
	{
		if(waves.isFinished())
		{
			if(pool.enemies.Count == 0)
			{
				Win();
			}
		}
	}

	void Win ()
	{
		GameStateManager.GameEvent = GameEvent.Win;

		Main.instance.score.AddScore(CalculateStars());
	}

	void CheckLose ()
	{
		if(gameData.lives <= 0)
			Lose();
	}

	void Lose()
	{
		GameStateManager.GameState = GameState.Dead;
		GameStateManager.GameEvent = GameEvent.GameOver;
	}

	public int CalculateStars()
	{
		if(gameData.lives > ((gameData.maxLives/4) *3))
			return 3;
		else if(gameData.lives > ((gameData.maxLives/4) *2))
			return 2;

		return 1;
	}

}
