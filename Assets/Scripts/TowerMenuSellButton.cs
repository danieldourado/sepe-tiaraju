using UnityEngine;
using System.Collections;

public class TowerMenuSellButton : MonoBehaviour 
{
	private TowerMenu towerMenu;
	private bool isFirstClick;
	public AudioClip sellTowerSound;
	
	public void Start()
	{
		towerMenu = FindObjectOfType<TowerMenu>();
	}

	public void Sell()
	{
		towerMenu.SellTower();
		Main.instance.audioManager.PlayAudio(sellTowerSound);
	}
}
