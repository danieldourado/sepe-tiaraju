using UnityEngine;
using System.Collections;

public class TowerWarrior : MonoBehaviour 
{
	
	public bool isReloaded = false;
	public float remainingTimeToReload = 0;
	
	
	private DamageData damageData;
	private DuelData duelData;
	private Weapon weapon;
	private EnemyOnRangeNoCollider enemyOnRangeChecker;
	
	
	public void Setup(DamageData data)
	{
		this.damageData = data;
		gameObject.name = "Shooter";
		
		enemyOnRangeChecker = gameObject.AddComponent<EnemyOnRangeNoCollider>();
		enemyOnRangeChecker.Setup(damageData);
		weapon = gameObject.AddComponent<Weapon>();
		transform.localPosition = Vector3.zero;
	}
	
	public void Setup(DamageData data, DuelData duelData)
	{
		this.duelData = duelData;
		Setup(data);
	}
	
	void Update()
	{
		UpdateReloadTime();
		Shoot();
	}
	
	void Shoot()
	{
		if(!isReloaded) return;
		if(!enemyOnRangeChecker.HasValidTargetOnRange()) return;
		if(duelData != null)
		{
			if(duelData.canAttack == false) 
				return;
		}
		
		Invoke("DoShoot", damageData.delayOfAttack);
		isReloaded = false;
	}

	void DoShoot()
	{
		weapon.Shoot(enemyOnRangeChecker.GetListOfTargets()[0], damageData);
		isReloaded = false;
	}
	
	void UpdateReloadTime()
	{
		if(isReloaded) return;
		
		remainingTimeToReload -= Time.deltaTime;
		if(remainingTimeToReload <= 0) 
		{
			isReloaded = true;
			remainingTimeToReload = damageData.reloadTime;
		}
	}
}
