using UnityEngine;
using System.Collections;

public class UITowerRange : MonoBehaviour 
{
	public void Start()
	{
		Hide();
	}

	public void Show(DamageData data)
	{
		gameObject.SetActive(true);
		transform.localScale = new Vector3(data.range, 0f, data.range);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}
}
