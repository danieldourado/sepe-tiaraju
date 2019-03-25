using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour 
{
	Health healthData;
	void Start()
	{
		healthData = GetComponent<Health>();
	}

	public void Update()
	{
		if(healthData.currentHealth <= 0)
		{
			Die ();
		}
	}

	void Die()
	{
		FindObjectOfType<GameData>().DecreaseLives(GetComponent<EnemyData>().damage);
	}
}
