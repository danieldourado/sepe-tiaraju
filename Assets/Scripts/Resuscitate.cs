using UnityEngine;
using System.Collections;

public class Resuscitate : MonoBehaviour 
{
	ReloadTimer timer;
	Health health;
	void Start () 
	{
		health = GetComponent<Health>();
		timer = gameObject.AddComponent<ReloadTimer>();
		timer.Setup(health.timeToResuscitate);
	}

	void Update () 
	{
		if(timer.isReloaded)
		{
			health.Start();
			Destroy(timer);
			Destroy(this);
		}
	}
}
