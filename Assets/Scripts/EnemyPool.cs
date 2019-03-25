using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour 
{

	private List<GameObject> listOfEnemies;
	private int numberOfObjectsToPool = 10;

	public void Start()
	{
		listOfEnemies = new List<GameObject>();

		while(listOfEnemies.Count < numberOfObjectsToPool)
		{
			PoolNewObject();
		}
	}
	
	void PoolNewObject ()
	{
		
	}

}
