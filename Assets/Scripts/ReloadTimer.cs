using UnityEngine;
using System.Collections;

public class ReloadTimer : MonoBehaviour 
{
	public bool isReloaded = false;
	public float remainingTimeToReload = 0;
	public float reloadTime = 1;
	private bool startReloaded;

	public void Start()
	{
		remainingTimeToReload = reloadTime;
		isReloaded = false;

		if(startReloaded)
		{
			isReloaded = true;
			remainingTimeToReload = 0f;
			startReloaded = false;
		}
	}

	public void Setup(float otherTimer, bool startReloaded = false)
	{
		this.reloadTime = otherTimer;
		this.startReloaded = startReloaded;
		//Start ();
	}

	void FixedUpdate()
	{
		UpdateReloadTime();
	}

	void UpdateReloadTime()
	{
		if(isReloaded) return;
		
		remainingTimeToReload -= Time.deltaTime;
		if(remainingTimeToReload <= 0) 
		{
			isReloaded = true;
			remainingTimeToReload = reloadTime;
		}
	}
}
