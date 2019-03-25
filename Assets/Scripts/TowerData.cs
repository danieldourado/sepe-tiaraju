using UnityEngine;
using System.Collections;

public class TowerData : MonoBehaviour 
{
	[HideInInspector]
	public float touchRadius = 50f;

	public int price = 100;

	[HideInInspector]
	public GameObject buildingSite;
	public GameObject upgradeTower;
	public TowerType towerType;
	
	public int numberOfUnitsInTower = 1;
	public GameObject warrior;

	public enum TowerType
	{
		Projectile,
		Warriors
	}
}
