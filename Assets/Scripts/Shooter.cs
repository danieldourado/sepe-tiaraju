using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour 
{
	
	public ReloadTimer reloadTimer;
	
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

		reloadTimer = gameObject.AddComponent<ReloadTimer>();
		reloadTimer.Setup(damageData.reloadTime);
	}

	public void Setup(DamageData data, DuelData duelData)
	{
		this.duelData = duelData;
		Setup(data);
	}
	
	void Update()
	{
		Shoot();
	}
	
	void Shoot()
	{
		if(!reloadTimer.isReloaded) return;
		if(!enemyOnRangeChecker.HasValidTargetOnRange()) return;
		if(duelData != null)
		{
			if(duelData.canAttack == false) 
				return;
		}


		transform.parent.GetComponentInChildren<Animator>().Play("Attacking");
		Invoke("DoShoot", damageData.delayOfAttack);
		reloadTimer.Start();
	}

	void DoShoot()
	{
		if(duelData != null)
		{
			if(duelData.canAttack == false) 
				return;
		}
		weapon.Shoot(enemyOnRangeChecker.GetPrefferedTarget(), damageData);

	}
}
