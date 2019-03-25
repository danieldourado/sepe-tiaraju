
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpecialHability : MonoBehaviour 
{
	
	public Upgrade.UpgradeType upgradeType;
	[HideInInspector]
	public bool isSelected;
	public List<GameObject> listaDeLevels;
	private GameObject specialHabilityPrefab;
	public float timeToExpire = 20f;
	public ReloadTimer timer;
	public GameEvent eventToRespondTo;
		
	public void Start () 
	{
		GameStateManager.OnGameEventChanged += CheckEvent;
		timer = gameObject.AddComponent<ReloadTimer>();
		timer.Setup(timeToExpire, true);

		SetPrefabToCurrentUpgrade();
	}
	
	private void CheckEvent(GameEvent ge)
	{
		if(ge == eventToRespondTo) SpecialHabilitySelectedHandler();
	}
	
	void SpecialHabilitySelectedHandler ()
	{
		if(isSelected)
		{
			FindObjectOfType<TouchOrganizer>().Hide();
		}
		else
		{
			FindObjectOfType<TouchOrganizer>().Hide();
			isSelected = true;
			Debug.Log(eventToRespondTo.ToString()+" Selected");
		}
	}
	
	public void Hide ()
	{
		if(isSelected)
		{
			Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;

			var specialHability = Instantiate<GameObject>(specialHabilityPrefab);
			specialHability.transform.position = target;
			
			FindObjectOfType<GroundFlag>().SetTarget(target);

			timer.Start();
		}
		
		isSelected = false;
		Debug.Log(eventToRespondTo.ToString()+" deSelected");
	}
	
	public bool IsAvaliable ()
	{
		return timer.isReloaded;
	}

	void SetPrefabToCurrentUpgrade ()
	{
		var currentLevel = Main.instance.score.GetUpgradeLevel(upgradeType);
		specialHabilityPrefab = listaDeLevels[currentLevel];
	}
}
