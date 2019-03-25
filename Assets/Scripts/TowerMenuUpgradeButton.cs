using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TowerMenuUpgradeButton : MonoBehaviour 
{
	private TowerMenu towerMenu;
	private Image image;
	private Color originalColor;

	
	public void Start()
	{
		image = GetComponent<Image>();
		originalColor = image.color;
		towerMenu = FindObjectOfType<TowerMenu>();
	}
	
	public void Upgrade()
	{
		if(HasMoney())
		{
			towerMenu.Upgrade();
		}
	}
	
	public void Update()
	{
		if(towerMenu.data == null) return;

		var button = transform.parent.GetComponentInChildren<Button>();

		
		if(!CanUpgrade())
		{
			image.enabled = false;
			button.enabled = false;
		}
		else
		{
			image.enabled = true;
			button.enabled = true;
		}
		
		if(HasMoney())
		{
			image.color = originalColor;
		}
		else
		{
			var newColor = new Color(originalColor.r, originalColor.g, originalColor.b, originalColor.a);
			newColor.a = 0.6f;
			image.color = newColor;
		}
	}
	
	bool HasMoney()
	{
		return FindObjectOfType<GameData>().money >= towerMenu.data.GetComponent<Tower>().price;
	}
	
	bool CanUpgrade()
	{
		bool canUpgrade = false;
		var currentLevel = Main.instance.currentLevel.ToString();
		var upgradeTower = towerMenu.data.GetComponent<Tower>().upgradeTower;
		if(upgradeTower == null) return false;
		
		var towerLevel = upgradeTower.GetComponent<Tower>().avaliableInLevel.ToString();
		int currentLevelNumber = Int32.Parse(currentLevel.Substring(currentLevel.Length-1));
		int towerLevelNumber = Int32.Parse(towerLevel.Substring(currentLevel.Length-1));
		if(currentLevelNumber >= towerLevelNumber)
			canUpgrade = true;
		
		return canUpgrade;
	}
	
	public void Sell()
	{
		towerMenu.SellTower();
	}
	
}
