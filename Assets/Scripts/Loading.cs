using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour 
{
	public GameObject loadingBar;
	public float progress
	{
		set
		{
			if(value != value) return;
			var rectTransform = loadingBar.GetComponent<RectTransform>();
			var width = rectTransform.rect.width;
			rectTransform.position = new Vector3(value*width - width, rectTransform.position.y, rectTransform.position.z);
		}
	}

	void Start () 
	{
		gameObject.SetActive(false);
	}


	void Update () 
	{
		
	}
}
