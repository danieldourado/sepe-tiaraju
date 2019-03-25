using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonWithConfirm : MonoBehaviour 
{
	
	public Sprite confirmSprite;
	private Sprite originalSprite;
	public Image iconImageComponent;

	// Use this for initialization
	void Start () 
	{
		originalSprite = iconImageComponent.sprite;
	}

	public void OnClick()
	{
		var btb = GetComponent<BuildTowerButton>();
		if(btb)
		{
			if(GetComponent<BuildTowerButton>().HasMoney() == false) return;
		}

		transform.parent.BroadcastMessage("ShowOriginalIcon", SendMessageOptions.DontRequireReceiver);
		iconImageComponent.overrideSprite = confirmSprite;
	}

	
	public void ShowOriginalIcon()
	{
		iconImageComponent.overrideSprite = originalSprite;
	}
}
