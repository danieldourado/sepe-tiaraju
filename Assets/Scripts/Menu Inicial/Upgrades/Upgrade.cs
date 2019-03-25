using UnityEngine;
using System.Collections.Generic;
using System;


public class Upgrade : MonoBehaviour 
{
	public List<UpgradeVO> currentUpgrades;

	public enum UpgradeType
	{
		Upgrade1,
		Upgrade2,
		Upgrade3,
		Upgrade4,
		Upgrade5,
		Upgrade6,
		Upgrade7,
		Upgrade8,
		Upgrade9
	}

	public enum UpgradeLevel
	{
		Level1,
		Level2,
		Level3,
		Level4,
		Level5
	}

	void Start () 
	{
	
	}
}

[Serializable]
public class UpgradeVO
{
	public Upgrade.UpgradeType type;
	public int level;
	public int price;
}
