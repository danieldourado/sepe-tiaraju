using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildTowerButton : MonoBehaviour 
{
	public GameObject towerToBuild;
	private Tower data;
	private Color originalColor;
	private GameData gameData;



	//private Text priceText;


	public void Start()
	{
		//iconImageComponent = transform.FindChild("Sprite").GetComponent<Image>();
		//originalSprite = iconImageComponent.sprite;

		data = towerToBuild.GetComponent<Tower>();

		GetComponentInChildren<Text>().text = data.price.ToString();
		//originalColor = iconImageComponent.color;
		//priceText = GetComponentInChildren<Text>();
	}

	public void Update()
	{
		if(HasMoney())
		{
			//iconImageComponent.color = originalColor;
		}
		else
		{
			//var newColor = new Color(originalColor.r, originalColor.g, originalColor.b, originalColor.a);
			//newColor.a = 0.6f;
			//iconImageComponent.color = newColor;
		}
	}
	

	public void OnClick()
	{
		//transform.parent.BroadcastMessage("ShowOriginalIcon", SendMessageOptions.DontRequireReceiver);
		if(HasMoney())
		{
			GameObject.FindObjectOfType<BuildTowerMenu>().Init(towerToBuild);
			//iconImageComponent.overrideSprite = confirmSprite;
		}
		//GameObject.FindObjectOfType<TowerFactory>().BuildTower(towerToBuild);
	}
	
	public bool HasMoney()
	{
		if(gameData == null)
			gameData = FindObjectOfType<GameData>();

		if(gameData == null)
			return false;

		return gameData.money >= data.price;
	}
}
