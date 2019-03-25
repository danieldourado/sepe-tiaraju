using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[ExecuteInEditMode]
public class GridContainer : MonoBehaviour 
{
	public List<GameObject> buttons;

	List<GameObject> children;

	void Start () 
	{
		children = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Application.isEditor && !Application.isPlaying) 
		{
			CheckGridLayoutComponent();
			CheckGameObjectsCreated();
			SetSizes();
		}
	}

	void CheckGridLayoutComponent ()
	{
		GridLayoutGroup glg = GetComponent<GridLayoutGroup>();
		if(glg == null)
		{
			glg = gameObject.AddComponent<GridLayoutGroup>();

		}


	}

	void CheckGameObjectsCreated ()
	{
		RemoveAll();
		foreach(GameObject tempButton in buttons)
		{
			if(tempButton == null) continue;
			children.Add(Instantiate<GameObject>(tempButton));
			children[children.Count-1].transform.SetParent(transform); 
		}
	}

	void RemoveAll ()
	{
		var children = new List<GameObject>();
		foreach (Transform child in transform) children.Add(child.gameObject);
		children.ForEach(child => DestroyImmediate(child));

		children = new List<GameObject>();
	}

	void SetSizes ()
	{
	 	GetComponent<RectTransform>().sizeDelta = GetComponent<GridLayoutGroup>().cellSize;
	}
}
