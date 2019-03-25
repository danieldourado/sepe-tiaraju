using UnityEngine;
using System.Collections;

public class TowerMenu : MonoBehaviour 
{
	private TowerRangeCircle towerRangeCircle;
	[HideInInspector]
	public InfoData data;
	private GameObject currentTowerToBuild;
	private BuildTowerMenuDescriptionPanel btmdp;

	void Awake()
	{
		towerRangeCircle = FindObjectOfType<TowerRangeCircle>();
		btmdp = FindObjectOfType<BuildTowerMenuDescriptionPanel>();

	}

	public void ShowMenuAtPosition(InfoData data)
	{
		this.data = data;

		transform.position = data.transform.position;
		
		//gameObject.SetActive(true);

		towerRangeCircle.Show(data.GetComponent<DamageData>());

		currentTowerToBuild = null;

		BroadcastMessage("ShowOriginalIcon", SendMessageOptions.DontRequireReceiver);
	}

	public void Hide ()
	{
		transform.position = new Vector3(-1000f, -1000f);
	}

	public void SellTower ()
	{
		data.gameObject.GetComponent<Tower>().Sell();
		FindObjectOfType<TouchOrganizer>().Hide();
		Main.instance.score.playerData.progressData.towersSold++;
	}

	public void Upgrade ()
	{
		var towerData = data.GetComponent<Tower>();
		bool firstClick = currentTowerToBuild != towerData.upgradeTower;
		
		if(firstClick)
		{
			currentTowerToBuild = towerData.upgradeTower;
			ShowDetailsPanel(towerData.upgradeTower);
			//ShowTowerPreview(data.upgradeTower);
			//currentTowerBuildingSite.SetActive(false);
		}
		else
		{
			BuildTower(towerData.upgradeTower);
		}
	}
	
	public void BuildTower(GameObject towerToBuild)
	{
		GameObject.FindObjectOfType<TowerFactory>().UpgradeTower(data.GetComponent<Tower>());
		FindObjectOfType<TouchOrganizer>().Hide();
	}
	
	public void ShowDetailsPanel(GameObject towerToBuild)
	{
		var data = towerToBuild.GetComponent<InfoData>();
		btmdp.Show(data, transform.position);
	}
	
	void ShowTowerPreview (GameObject towerToBuild)
	{
		GameObject.FindObjectOfType<TowerFactory>().ShowTower(towerToBuild);
	}
}
