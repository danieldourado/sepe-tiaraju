using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildTowerMenuDescriptionPanel : MonoBehaviour 
{
	public Text title;
	public Text description;
	public Text data;

	private float width;

	public void Start()
	{
		width = GetComponent<RectTransform>().rect.width;
	}

	public void Show(InfoData infoData, Vector3 position)
	{
		var damageData = infoData.GetComponent<DamageData>();
		title.text = infoData.name;
		description.text = infoData.description;
		data.text = "Dano: "+damageData.damage_ammount+" Velocidade: "+damageData.reloadTime ;

		SetPosition(position);
	}

	public void ShowMessage(string message, Vector3 position)
	{
		title.text = string.Empty;
		description.text = message;
		data.text = string.Empty;
		
		SetPosition(position);
	}

	void SetPosition (Vector3 position)
	{
		var newPosition = position;
		//newPosition.x += 100f*2;
		newPosition.x += width*2;

		if(newPosition.x > 1400f)
		{
			newPosition = position;
			newPosition.x -= width*2;
		}

		transform.position = newPosition;
	}

	public void Hide()
	{
		transform.position = new Vector3(-1000, -1000);
	}
}
