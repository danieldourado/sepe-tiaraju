using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TowerTouchDetector : TouchDetector2D
{
	public void Setup(Tower data, GameObject go)
	{
		Setup(data.touchRadius, go);
	}
}
