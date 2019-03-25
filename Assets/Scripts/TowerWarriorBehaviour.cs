using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerWarriorBehaviour : MonoBehaviour 
{
	Tower towerData;
	DamageData damageData;
	List<GameObject> listOfWarriors;
	public float distanceBetweenWarriors = 40f;

	void Start () 
	{
		towerData = GetComponent<Tower>();
		damageData = GetComponent<DamageData>();
		CreateShooters();
	}
	
	void CreateShooters ()
	{
		listOfWarriors = new List<GameObject>();
		GameObject tempWarrior;

		var closestPath = FindNearestPath();
		var anchorPoint = new Vector3();

		for(int i = 1; i<=towerData.numberOfUnitsInTower; i++)
		{
			tempWarrior = Instantiate<GameObject>(GetComponent<Tower>().warrior);
			tempWarrior.transform.position = transform.position;

			anchorPoint.x = closestPath.x + (distanceBetweenWarriors * i) -distanceBetweenWarriors*2;
			anchorPoint.y = closestPath.y;

			tempWarrior.GetComponent<AllyDuel>().SetAsTowerWarrior(anchorPoint, transform);

			listOfWarriors.Add(tempWarrior);
		}
		//listOfWarriors[0].transform.position = closestPath;
	}

	void Update()
	{
		foreach(var tempWarrior in listOfWarriors)
		{
			var health = tempWarrior.GetComponent<Health>();
			if(health.isDead)
			{
				if(!tempWarrior.GetComponent<Resuscitate>())
				{
					tempWarrior.AddComponent<Resuscitate>();
				}
			}
		}
	}


	Vector3 FindNearestPath()
	{
		var paths = FindObjectsOfType<iTweenPath>();
		Vector3 currentPosition = transform.position;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 closestPoint = Vector3.zero;

		foreach(iTweenPath tempPath in paths)
		{
			if(tempPath.name != "WarriorTowerPoint") continue;
			foreach(Vector3 tempNode in tempPath.nodes)
			{
				Vector3 directionToTarget = tempNode - currentPosition;
				float dSqrToTarget = directionToTarget.sqrMagnitude;
				if(dSqrToTarget < closestDistanceSqr)
				{
					closestDistanceSqr = dSqrToTarget;
					closestPoint = tempNode;
				}
			}
		}
		return closestPoint;
	}

	public void DestroyWarriors ()
	{
		foreach(var tempWarrior in listOfWarriors)
		{
			Destroy(tempWarrior);
		}
	}
}
