using UnityEngine;
using System.Collections;

public class Expirer : MonoBehaviour 
{
	ReloadTimer timer;
	private float timeToExpire;
	// Use this for initialization
	void Start () {
		timer = gameObject.AddComponent<ReloadTimer>();
		timer.Setup(timeToExpire);
		timer.Start();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(timer.isReloaded)
			Destroy(gameObject);
	
	}

	public void Setup (float timeToExpire)
	{
		this.timeToExpire = timeToExpire;
	}
}
