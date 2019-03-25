using UnityEngine;
using System.Collections;

public class BuildTowerMenu : MonoBehaviour 
{
	private GameObject currentTowerBuildingSite;
	private GameObject currentTowerToBuild;
	private BuildTowerMenuDescriptionPanel btmdp;

	void Awake()
	{
		btmdp = FindObjectOfType<BuildTowerMenuDescriptionPanel>();
	}

	void Start () 
	{
		Hide();
	}

	public void ShowMenuAtPosition(Vector3 position, GameObject towerBuildingSite)
	{
		Hide();

		currentTowerBuildingSite = towerBuildingSite;

		//transform.position = position;
		Main.instance.showWithEffect.ShowAtPosition(gameObject, position);

		BroadcastMessage("ShowOriginalIcon", SendMessageOptions.DontRequireReceiver);

	}

	
	public void Hide ()
	{
		currentTowerToBuild = null;
		btmdp.Hide();
		GameObject.FindObjectOfType<TowerFactory>().Hide();
		if(currentTowerBuildingSite) currentTowerBuildingSite.SendMessage("EnableTouch");

		//Main.instance.showWithEffect.HideAtDefaultPosition(gameObject);
		transform.position = new Vector3(-1000f,-1000f);

	}

	public void Init (GameObject towerToBuild)
	{
		bool firstClick = currentTowerToBuild != towerToBuild;

		if(firstClick)
		{
			currentTowerToBuild = towerToBuild;
			ShowDetailsPanel(towerToBuild);
			ShowTowerPreview(towerToBuild);
			currentTowerBuildingSite.SendMessage("DisableTouch");
		}
		else
		{
			BuildTower(towerToBuild);
		}
	}

	public void BuildTower(GameObject towerToBuild)
	{
		GameObject.FindObjectOfType<TowerFactory>().BuildTower(towerToBuild, currentTowerBuildingSite);
		currentTowerBuildingSite = null;
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
