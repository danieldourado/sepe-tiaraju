using UnityEngine;
using System.Collections;

public class EnemyKillCounter : MonoBehaviour 
{
	Health healthComponent;
	bool isDone;

	void Start () 
	{
		healthComponent = GetComponent<Health>();
	}

	void Update () 
	{
		if(isDone) return;

		if(healthComponent.isDead)
		{
			Main.instance.score.playerData.progressData.kills ++;
			isDone = true;
		}
	}
}
