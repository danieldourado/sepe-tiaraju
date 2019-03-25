using UnityEngine;
using System.Collections;

public class TowerFactory : MonoBehaviour 
{
	public AudioClip buildTowerSound;

	public enum TowerList
	{
		Tower1,
		Tower2,
		Tower3,
		Tower4,
		Tower5,
		Tower6,
		Tower7,
		Tower8,
		Tower9,
		Tower10
	}

	public AudioClip sellTowerSound;
	private BuildTowerMenu btm;
	private Transform towersContainer;
	private GameObject previewTower;

	void Awake () 
	{
		btm = GameObject.FindObjectOfType<BuildTowerMenu>();
		CreateTowersContainer();
	}

	void CreateTowersContainer ()
	{
		var go = new GameObject();
		go.name = "Towers";
		towersContainer = go.transform;
	}

	public void ShowTower (GameObject towerToBuild)
	{
		DestroyPreviewTower();
		previewTower = Instantiate<GameObject>(towerToBuild);
		Destroy(previewTower.GetComponent<Tower>());
		previewTower.transform.SetParent(towersContainer);

		Vector3 towerPosition = btm.transform.position;
		towerPosition.z = 0f;

		previewTower.transform.position = towerPosition;
		previewTower.name = "Preview";

		FindObjectOfType<TowerRangeCircle>().Show(previewTower.GetComponent<DamageData>());

		GameStateManager.GameEvent = GameEvent.TowerPreview;
	}

	public void BuildTower(GameObject towerToBuild, GameObject towerBuildingSite)
	{
		DestroyPreviewTower();
		Vector3 position = btm.transform.position;
		GameObject tempTower = Instantiate<GameObject>(towerToBuild);
		tempTower.transform.SetParent(towersContainer);

		Vector3 towerPosition = btm.transform.position;
		towerPosition.z = 0f;

		tempTower.transform.position = towerPosition;
		var towerData = tempTower.GetComponent<Tower>();
		towerData.buildingSite = towerBuildingSite;

		GameStateManager.GameEvent = GameEvent.TowerBuilt;

		FindObjectOfType<GameData>().DecreaseMoney(towerData.price);

		Main.instance.score.playerData.progressData.builtTowers++;
		Main.instance.audioManager.PlayAudio(buildTowerSound);
	}

	public void UpgradeTower(Tower towerData)
	{
		GameObject newTower = Instantiate<GameObject>(towerData.upgradeTower);
		newTower.transform.SetParent(towersContainer);

		Vector3 towerPosition = towerData.gameObject.transform.position;
		towerPosition.z = 0f;
		
		newTower.transform.position = towerPosition;
		var newTowerData = newTower.GetComponent<Tower>();
		newTowerData.buildingSite = towerData.buildingSite;

		GameStateManager.GameEvent = GameEvent.TowerBuilt;

		Destroy(towerData.gameObject);

		FindObjectOfType<GameData>().DecreaseMoney(towerData.price);
	}

	public void Hide()
	{
		if(previewTower)
		{
			previewTower.SetActive(false);
			Destroy(previewTower);
			previewTower = null;
		}
	}

	void DestroyPreviewTower()
	{
		if(previewTower) Destroy(previewTower);
	}
}
