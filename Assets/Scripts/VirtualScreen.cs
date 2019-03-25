using UnityEngine;
using System.Collections;

public class VirtualScreen : MonoBehaviour 
{

	private GameObject currentShow;
	public GameObject currentShowPrefab;


	public void Awake()
	{
		gameObject.name = "Virtual Screen";
		gameObject.AddComponent<RectTransform>();
		GetComponent<RectTransform>().pivot = Vector2.zero;  	
		GetComponent<RectTransform>().sizeDelta = new Vector2( 1920, 1080);
		

	}

	public void Show(GameObject objToShow)
	{
		RemoveCurrent();
		currentShowPrefab = objToShow;
		currentShow = Instantiate<GameObject>(objToShow);
		currentShow.transform.SetParent(transform);
		currentShow.GetComponent<RectTransform>().position = Vector2.zero;
	}

	void RemoveCurrent ()
	{
		if(currentShow)
		{
			transform.DetachChildren();
			currentShow.SetActive(false);
			Destroy(currentShow);
		}
	}

	public void Destroy()
	{
		RemoveCurrent();
		Destroy(gameObject);
	}
}
