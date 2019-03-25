using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyOnRangeNoCollider : MonoBehaviour 
{
	private List<GameObject> listOfTargets;
	
	
	DamageData data;
	public GameObject prefferedTarget;

	public void Start()
	{
		listOfTargets = new List<GameObject>();
	}

	public void Setup (DamageData damageData)
	{
		data = damageData;
		
	}

	public GameObject GetPrefferedTarget()
	{
		if(prefferedTarget == null)
			return listOfTargets[0];

		return prefferedTarget;
	}
	
	public bool HasValidTargetOnRange(EnemyDuel targetToCheck = null)
	{
		if(targetToCheck)
			return listOfTargets.Any(tempTarget => tempTarget == targetToCheck.gameObject);

		if(listOfTargets != null)
			return listOfTargets.Count > 0;

		return false;
	}
	
	public List<GameObject> GetListOfTargets()
	{
		return listOfTargets;
	}
	
	void Update()
	{
		CreateListOfTargets();
	}

	void CreateListOfTargets()
	{
		listOfTargets = new List<GameObject>();

		Vector2 position = transform.position;

		var units = Physics2D.OverlapCircleAll(position, data.range);


		foreach(Collider2D collider in units)
		{
			var go = collider.gameObject;

			var enemyComponent = go.GetComponent<Enemy>();
			Health healthComponent = go.GetComponent<Health>();
			if(enemyComponent && healthComponent)
			{
				if(healthComponent.canTakeDamage) 
				{
					listOfTargets.Add(go);
				}
			}
		}
	}
	/*
	bool CheckIfStillOnRange()
	{
		if(listOfTargets)
		{

			if(data.weaponType == DamageData.WeaponType.Warrior)
			{
				var enemyDuelData = currentTarget.GetComponent<DuelData>();
				var myAllyDuel = transform.parent.GetComponentInChildren<AllyDuel>();
				if((enemyDuelData.isOnDuel)&&(enemyDuelData.duelingWith != myAllyDuel))
					return false;
			}

			float distance = Vector2.Distance(transform.position, 
			                                  listOfTargets.transform.position);

			if(distance > data.range)
				return false;

			if(listOfTargets.GetComponent<Health>().canTakeDamage == false)
				return false;
		}
		return true;
	}
*/


	
}
