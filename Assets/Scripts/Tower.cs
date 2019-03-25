using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[RequireComponent(typeof(InfoData))]

public class Tower : MonoBehaviour
{
	[HideInInspector]
	public float touchRadius = 50f;
	
	public int price = 100;

	public Level.LevelScenes avaliableInLevel = Level.LevelScenes.Level_1;
	
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

	DamageData damageData;
	public void Start () 
	{

		Main.instance.audioManager.PlayAudio(Main.instance.sounds.construirTorre);
		damageData = GetComponent<DamageData>();

		switch(towerType)
		{
			case Tower.TowerType.Projectile:
				//gameObject.AddComponent<TowerShooterBehaviour>();
			break;

			case Tower.TowerType.Warriors:
				gameObject.AddComponent<TowerWarriorBehaviour>();
			break;
		}

		CreateTouchDetector();

		/*
		var damageDataInChildren =  GetComponentsInChildren(typeof(DamageData));

		foreach(DamageData tempDamage in damageDataInChildren)
		{
			tempDamage.armorPiercing = damageData.armorPiercing;
			tempDamage.damage_ammount = damageData.damage_ammount;
			tempDamage.maxTimeProjectileStaysInAir = damageData.maxTimeProjectileStaysInAir;
			tempDamage.projectile = damageData.projectile;
			tempDamage.range = damageData.range;
			tempDamage.reloadTime = damageData.reloadTime;
			tempDamage.shootsFlier = damageData.shootsFlier;
			tempDamage.weaponType = damageData.weaponType;

		}
*/

		var shooters = GetComponentsInChildren<DamageData>();
		foreach(DamageData tempData in shooters)
		{
			DamageData towerData = GetComponent<DamageData>();
			tempData.armorPiercing = towerData.armorPiercing;
			tempData.damage_ammount = towerData.damage_ammount;
			tempData.damage_area = towerData.damage_area;
			tempData.maxTimeProjectileStaysInAir = towerData.maxTimeProjectileStaysInAir;
			tempData.projectile = towerData.projectile;
			tempData.range = towerData.range;
			tempData.reloadTime = towerData.reloadTime;
			tempData.shootsFlier = towerData.shootsFlier;
			tempData.weaponType = towerData.weaponType;

		}

	}


	void CreateTouchDetector ()
	{
		GameObject touchDetector = new GameObject();
		touchDetector.transform.SetParent(transform);
		touchDetector.AddComponent<TowerTouchDetector>().Setup(GetComponent<Tower>(), gameObject);
		touchDetector.transform.localPosition = Vector3.zero;
	}

	public void OnClick()
	{
		FindObjectOfType<TowerMenu>().ShowMenuAtPosition(GetComponent<InfoData>());
		Main.instance.audioManager.PlayAudio(GetComponent<InfoData>().clickSound);
	}

	public void OnDestroy()
	{
		if(towerType == TowerType.Warriors)
		{
			var tb = GetComponent<TowerWarriorBehaviour>();
			if(tb)
				tb.DestroyWarriors();
		}
	}

	public void Sell()
	{
		Main.instance.audioManager.PlayAudio(Main.instance.sounds.venderTorre);
		FindObjectOfType<GameData>().SellTower(GetComponent<Tower>());
		GetComponent<Tower>().buildingSite.SendMessage("EnableTouch");

		Destroy(gameObject);
	}

	public bool CanUpgrade()
	{
		return false;
	}

}
