using UnityEngine;
using System.Collections;

public class EnemyReseter : MonoBehaviour 
{

	Health healthData;
	EnemyData enemyData;
	bool isReset;

	void Start()
	{
		healthData = GetComponent<Health>();
		enemyData = GetComponent<EnemyData>();
	}

	public void Update()
	{
		CheckHealth();
		if(enemyData) CheckEndOfPath();
	}

	void CheckHealth ()
	{
		if(isReset) return;

		if(healthData.isDead)
			Killed();

	}

	void CheckEndOfPath ()
	{
		return;
		float timePassed = Time.time - enemyData.tweenInfo.startTime;
		if((enemyData.tweenInfo.tween != null) && (timePassed >= enemyData.tweenInfo.tween.time))
		{
			Passed();
		}
	}

	private void SendResetMessage()
	{
		SendMessage("Reset");
		Destroy(gameObject);
	}

	private void Killed()
	{
		isReset = true;
		FindObjectOfType<GameData>().IncreaseMoney(enemyData.reward);
		Invoke("SendResetMessage", healthData.timeToResuscitate);
	}

	public void Passed()
	{
		FindObjectOfType<GameData>().DecreaseLives(enemyData.damage);
		SendResetMessage();
	}
}
