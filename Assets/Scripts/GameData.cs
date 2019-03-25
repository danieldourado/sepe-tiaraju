using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour 
{
	public int money = 100;
	public int lives = 20;
	public int maxLives;

	void Start()
	{
		maxLives = lives;
	}

	public void DecreaseLives (int damage)
	{
		lives -= damage;
		Handheld.Vibrate();
	}

	public void IncreaseMoney (int ammount)
	{
		money += ammount;
	}

	public void DecreaseMoney (int ammount)
	{
		money -= ammount;
	}

	public void SellTower (Tower data)
	{
		float sellMoney = data.price * Main.instance.settings.SELL_FACTOR;

		IncreaseMoney((int)sellMoney);
	}
}
