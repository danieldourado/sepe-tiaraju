using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerShooterBehaviour : MonoBehaviour 
{
	Tower towerData;
	DamageData damageData;
	List<Shooter> listOfShooters;

	void Start () 
	{
		towerData = GetComponent<Tower>();
		damageData = GetComponent<DamageData>();
		CreateShooters();
	}

	void CreateShooters ()
	{
		listOfShooters = new List<Shooter>();
		GameObject tempShooter;
		
		for(int i = 1; i<=towerData.numberOfUnitsInTower; i++)
		{
			tempShooter = new GameObject();
			tempShooter.transform.SetParent(transform);
			Shooter shooterScript = tempShooter.AddComponent<Shooter>();
			shooterScript.Setup(damageData);
			listOfShooters.Add(shooterScript);
		}
		
		if(towerData.numberOfUnitsInTower ==2)
		{
			listOfShooters[0].transform.localPosition = new Vector3(-5f,0f,0f);
			listOfShooters[1].transform.localPosition = new Vector3(5f,0f,0f);
		}
	}

}
