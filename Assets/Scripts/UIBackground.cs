using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UIBackground : MonoBehaviour 
{
	List<GameObject> objectsToHide;
	void Awake () 
	{
		objectsToHide = new List<GameObject>();
		objectsToHide.Add(GameObject.FindObjectOfType<BuildTowerMenu>().gameObject);
		objectsToHide.Add(GameObject.FindObjectOfType<TowerRangeCircle>().gameObject);
		gameObject.AddComponent<TouchDetector2D>().Setup(2000f, gameObject);
	}
	
	public void OnClick()
	{
		foreach(GameObject go in objectsToHide)
		{
			go.SendMessage("Hide", SendMessageOptions.DontRequireReceiver);
		}
	}
}
