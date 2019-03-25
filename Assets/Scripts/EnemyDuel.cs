using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyDuel : MonoBehaviour 
{
	DuelData duelData;
	List<AllyDuel> listOfAllyToDuel;
	AllyDuel currentTarget;
	void Start () 
	{
		duelData = GetComponent<DuelData>();
		listOfAllyToDuel = new List<AllyDuel>();
	}

	public void ArrangeDuel(AllyDuel allyToDuel)
	{
		bool has = listOfAllyToDuel.Any(tempAlly => tempAlly == allyToDuel);
		if(has) return;

		listOfAllyToDuel.Add(allyToDuel);
	}

	public void DisengageDuel(AllyDuel allyToDuel)
	{
		bool has = listOfAllyToDuel.Any(tempAlly => tempAlly == allyToDuel);
		if(has == false) return;

		listOfAllyToDuel.Remove(allyToDuel);
	}


	void Update()
	{
		duelData.isOnDuel = listOfAllyToDuel.Count > 0;

		if(duelData.isOnDuel)
		{
			GetCurrentTarget();
			duelData.canAttack = currentTarget != null;
		}
		else
		{
			duelData.canAttack = false;
		}


	}

	public GameObject GetValidTarget ()
	{
		return currentTarget.gameObject;
	}

	void GetCurrentTarget()
	{
		List<AllyDuel> listOfTargets = listOfAllyToDuel.Where(tempAlly => tempAlly.duelData.canAttack == true).ToList();
		if(listOfTargets.Count == 0)
		{
			currentTarget = null;
			return;
		}
		currentTarget = listOfTargets[0];
	}
	
	public bool IsOnDuelWithOtherThanMe (AllyDuel allyDuelToCheck)
	{
		bool has = listOfAllyToDuel.Any(tempAlly => tempAlly != allyDuelToCheck);
		return has;
	}

	public bool IsDuelingWithMoreThanMe ()
	{
		return listOfAllyToDuel.Count > 1;
	}
}
