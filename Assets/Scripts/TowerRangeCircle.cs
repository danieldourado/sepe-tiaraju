using UnityEngine;
using System.Collections;

public class TowerRangeCircle : MonoBehaviour
{
	float defaultSize = 233.5f;

	public void Awake()
	{
		gameObject.name = "Range Circle";
	}


	public void Show(DamageData data)
	{
		var position = data.gameObject.transform.position;
		var normalizedRange = data.range / defaultSize;
		normalizedRange *= 0.5f;

		transform.localScale = new Vector3(normalizedRange*2, normalizedRange*1.6f, 1f);
		position.z =0f;
		transform.position = position;
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		transform.position = new Vector3(-1000f, -1000f);
	}
}
