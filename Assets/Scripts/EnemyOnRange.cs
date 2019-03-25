using UnityEngine;
using System.Collections;

[System.Obsolete("Use EnemyOnRangeNoCollider",true)]
public class EnemyOnRange : MonoBehaviour 
{
	private CircleCollider2D cc;
	private GameObject currentTarget;
	private GameObject targetAlreadyInBattle;

	
	DamageData data;
	void Start()
	{
		cc = gameObject.AddComponent<CircleCollider2D>();
		cc.isTrigger = true;
		gameObject.AddComponent<Rigidbody2D>().isKinematic = true;
	}

	public void Setup (DamageData damageData)
	{
		data = damageData;

	}

	public bool HasValidTargetOnRange()
	{
		return currentTarget != null;
	}

	public GameObject GetValidTarget()
	{
		return currentTarget;
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if(currentTarget) return;
		CheckIfTargetIsValid(collider.gameObject);
	}

	
	void CheckIfTargetIsValid (GameObject go)
	{
		if(go == null) return;

		var enemyComponent = go.GetComponent<Enemy>();
		Health healthComponent = go.GetComponent<Health>();
		if(enemyComponent && healthComponent)
		{
			if(healthComponent.canTakeDamage) 
			{
				currentTarget = go;
			}
			else currentTarget = null;
		}
		else
			currentTarget = null;
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if(currentTarget)
		{
			if(currentTarget == collider.gameObject)
				currentTarget = null;
		}
	}
	
	void Update()
	{
		cc.radius = data.range;
		CheckIfTargetIsValid(currentTarget);
	}
}
