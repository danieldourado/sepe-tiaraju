using UnityEngine;
using System.Collections;

public class AllyDuel : MonoBehaviour 
{
	[HideInInspector]
	public GameObject shooterGO;
	[HideInInspector]
	public Shooter shooter;
	[HideInInspector]
	public EnemyOnRangeNoCollider enemyOnRange;
	[HideInInspector]
	public DuelData duelData;

	private EnemyDuel enemyDuel;
	private MoverData moverData;
	private Vector3 positionOffset;
	private Health healthData;
	private Transform towerTransform;
	private Vector3 anchorPoint;
	private bool isHeroOrReinforcement = true;

	public void Start()
	{
		positionOffset = new Vector3(Random.Range(40f,60f),Random.Range(-10f,10f));
		duelData = GetComponent<DuelData>();

		shooterGO = new GameObject();
		shooterGO.transform.SetParent(transform);
		shooterGO.transform.localPosition = Vector3.zero;
		shooter = shooterGO.AddComponent<Shooter>();

		shooter.Setup(GetComponent<DamageData>(), duelData);
		enemyOnRange = shooterGO.GetComponent<EnemyOnRangeNoCollider>();
		enemyOnRange.Setup(GetComponent<DamageData>());
		moverData = GetComponent<MoverData>();
		healthData = GetComponent<Health>();

		if(towerTransform)
		{
			//enemyOnRange.transform.SetParent(towerTransform);
			enemyOnRange.transform.position = towerTransform.position;
		}
		if(anchorPoint != null)
		{
			GetComponent<MoveToPoint>().SetTarget(this.anchorPoint);
		}

		if(isHeroOrReinforcement == false)
			InvokeRepeating("CheckIfThereIsOtherNonDuelingTarget", 1f, 1f);

	}

	
	public void SetAsTowerWarrior(Vector3 anchorPoint, Transform towerTransform)
	{
		this.anchorPoint = anchorPoint;
		this.towerTransform = towerTransform;
		isHeroOrReinforcement = false;
	}
	
	public void SetAsReinforcementWarrior(Vector3 anchorPoint)
	{
		this.anchorPoint = anchorPoint;
	}
	

	public void Update()
	{
		if(towerTransform)
		{
			enemyOnRange.transform.position = towerTransform.position;
		}

		if(healthData.isDead)
		{
			CancelDuel();
			return;
		}

		if(enemyDuel)
		{
			if(enemyDuel.GetComponent<Health>().isDead)
			{
				CancelDuel();
				return;
			}
		}

		if(moverData.isMoving && (duelData.isMovingToDuel == false))
		{
			CancelDuel();
			return;
		}

		if(moverData.isMoving)
			duelData.canAttack = false;

		if(!enemyOnRange.HasValidTargetOnRange(enemyDuel))
		{
			CancelDuel();
			return;
		}

		if(enemyDuel == null)
		{
			enemyDuel = GetNonDuelingTarget();
		}

		PrepareToDuel();
	}
	
	void PrepareToDuel ()
	{
		enemyOnRange.prefferedTarget = enemyDuel.gameObject;
		enemyDuel.ArrangeDuel(this);

		duelData.isOnDuel = true;

		var positionToDuel = enemyDuel.transform.position + positionOffset;
		
		if(transform.position == positionToDuel)
		{
			StartDuel();
			return;
		}
		
		GetComponent<MoveToPoint>().SetTarget(positionToDuel, true);
	}

	public void CancelDuel()
	{
		if(enemyDuel) 
		{
			enemyDuel.DisengageDuel(this);
			enemyDuel = null;
		}

		duelData.canAttack = false;

		if(healthData.isDead) return;

		if(towerTransform)
			GetComponent<MoveToPoint>().SetTarget(this.anchorPoint);
	}

	EnemyDuel GetNonDuelingTarget ()
	{
		//return enemyOnRange.GetListOfTargets()[0].GetComponent<EnemyDuel>();
		//
		//
		var targets = enemyOnRange.GetListOfTargets();
		foreach(GameObject tempEnemy in targets)
		{
			var tempEnemyDuel = tempEnemy.GetComponent<EnemyDuel>();
			if(tempEnemyDuel.IsOnDuelWithOtherThanMe(this))
			{
				continue;
			}
			else
			{
				return tempEnemyDuel;
			}
		}
		if(enemyOnRange.GetListOfTargets().Count > 0)
			return enemyOnRange.GetListOfTargets()[0].GetComponent<EnemyDuel>();
		return null;
	}

	void CheckIfThereIsOtherNonDuelingTarget()
	{
		if(enemyDuel)
		{
			if(enemyDuel.IsDuelingWithMoreThanMe() == false) return;
		}
		var target = GetNonDuelingTarget();
		if(target != enemyDuel)
		{
			CancelDuel();
			enemyDuel = target;
			PrepareToDuel();
		}
	}

	void StartDuel ()
	{
		duelData.canAttack = true;
	}

	void OnDestroy()
	{
		CancelDuel();
	}
}
