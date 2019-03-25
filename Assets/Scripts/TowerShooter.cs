using UnityEngine;
using System.Collections;

public class TowerShooter : MonoBehaviour 
{
	private ReloadTimer reloadTimer;
	private DamageData damageData;
	private DuelData duelData;
	private Weapon weapon;
	private EnemyOnRangeNoCollider enemyOnRangeChecker;
	private Animator animator;
	private GameObject target;



	public void Start()
	{
		this.damageData = GetComponentInParent<DamageData>();
		gameObject.name = "Shooter";

		animator = GetComponent<Animator>();
		
		enemyOnRangeChecker = gameObject.AddComponent<EnemyOnRangeNoCollider>();
		enemyOnRangeChecker.Setup(damageData);
		weapon = gameObject.AddComponent<Weapon>();
		//transform.localPosition = Vector3.zero;
		
		reloadTimer = gameObject.AddComponent<ReloadTimer>();
		reloadTimer.Setup(damageData.reloadTime);
	}
	
	void FixedUpdate()
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

		animator.Play("Attacking");
		Invoke("DoShoot", damageData.delayOfAttack);
		target = enemyOnRangeChecker.GetListOfTargets()[0];

		FaceTheTarget();

		reloadTimer.Start();
	}

	void DoShoot()
	{
		if(duelData != null)
		{
			if(duelData.canAttack == false) 
				return;
		}

		weapon.Shoot(target, damageData);
		target = null;
	}


	private Vector3 mirroredScale = new Vector3(-1f, 1f,1f);
	private Vector3 notMirroredScale = new Vector3(1f, 1f,1f);
	void FaceTheTarget ()
	{
		var myX = transform.position.x;
		var targetX = target.transform.position.x;

		if(targetX > myX)
		{
			transform.localScale = notMirroredScale;
		}
		else
		{
			transform.localScale = mirroredScale;
		}
	}
}
