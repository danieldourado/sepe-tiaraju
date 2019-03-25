using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArchievementBadge : MonoBehaviour 
{
	[Range(1, 100)]
	public int badgeID;

	void Start () 
	{
		CheckAvaliability();
	}

	void CheckAvaliability ()
	{
		var archievementBadges = Main.instance.score.playerData.archievementBadges;

		foreach(int badgeID in archievementBadges)
		{
			if(this.badgeID == badgeID)
			{
				SetAvaliability(true);
				return;
			}
		}
		SetAvaliability(false);
	}

	void SetAvaliability (bool b)
	{
		if(b == false)
		{
			var color = new Color(255f,255f,255f, 0.3f);
			GetComponent<Image>().color = color;
		}
		else
		{
			var color = new Color(255f,255f,255f, 1f);
			GetComponent<Image>().color = color;
		}
	}

	public void Show()
	{
		Transform canvasTransform = GameObject.FindGameObjectWithTag("UICanvas").transform;
		transform.SetParent(canvasTransform);
		transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,0,0);
		Invoke("Hide", 5f);
	}

	public void Hide()
	{
		Destroy(gameObject);
	}

}
