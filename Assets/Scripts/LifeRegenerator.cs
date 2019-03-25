using UnityEngine;
using System.Collections;

public class LifeRegenerator : MonoBehaviour 
{
	Health health;
	ReloadTimer reloadTimer;

	void Start () 
	{
		health = GetComponent<Health>();
		reloadTimer = gameObject.AddComponent<ReloadTimer>();
		reloadTimer.Setup(1f);
	}

	void Update () 
	{
		if(reloadTimer.isReloaded)
		{
			if(health.isDead) return;
			health.Heal(health.renenerationPerSecond);
			reloadTimer.Start();
		}
	}
}
