using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour 
{
	
	public bool isReloaded = false;
	public float remainingTimeToReload = 0;
	
	
	private DamageData damageData;
	private DuelData duelData;
	private Weapon weapon;
	private EnemyDuel enemyDuel;
	
	
	private void Setup(DamageData data)
	{
		this.damageData = data;
		gameObject.name = "Shooter";
		weapon = gameObject.AddComponent<Weapon>();
		transform.localPosition = Vector3.zero;
		enemyDuel = GetComponentInParent<EnemyDuel>();
	}
	
	public void Setup(DamageData data, DuelData duelData)
	{
		this.duelData = duelData;
		Setup(data);
	}
	
	void FixedUpdate()
	{
		UpdateReloadTime();
		Shoot();
	}
	
	void Shoot()
	{
		if(!isReloaded) return;

		if(duelData.canAttack == false) 
			return;

		transform.parent.GetComponentInChildren<Animator>().Play("Attacking");
		Invoke("DoShoot", damageData.delayOfAttack);
		isReloaded = false;
	}

	void DoShoot()
	{
		if(duelData.canAttack == false) 
			return;
		weapon.Shoot(enemyDuel.GetValidTarget(), damageData);
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
