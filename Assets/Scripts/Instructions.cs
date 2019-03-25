using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Instructions : MonoBehaviour 
{
	public List<GameObject> screens;
	private VirtualScreen virtualScreen;


	public void Start()
	{
		if(Main.instance.currentLevel != Level.LevelScenes.Level_1)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			GetComponent<RectTransform>().position = Vector3.zero;
		}
		CreateVirtualScreen();
		ShowScreenNumber(0);
	}

	void CreateVirtualScreen ()
	{
		if(virtualScreen) virtualScreen.Destroy();
		GameObject go = new GameObject();
		go.transform.SetParent(transform);
		virtualScreen = go.AddComponent<VirtualScreen>();
	}
	

	public void ShowScreenNumber(int screenNumber)
	{
		if(screenNumber > screens.Count-1)
		{
			Destroy ();
			return;
		}
		virtualScreen.Show(screens[screenNumber]);
	}

	public void ShowNext()
	{
		ShowScreenNumber(IndexOfCurrent()+1);
	}

	public void ShowPrevious()
	{
		ShowScreenNumber(IndexOfCurrent()-1);
	}

	public void Skip ()
	{
		Destroy();
	}

	int IndexOfCurrent()
	{
		return screens.IndexOf(virtualScreen.currentShowPrefab);
	}

	public void Destroy()
	{
		virtualScreen.Destroy();
		Destroy(gameObject);
	}

	void Update()
	{
		
		//GetComponent<RectTransform>().pivot = new Vector2(0.5f,0.6f);  	
		//GetComponent<RectTransform>().position = Vector2.zero;
	}
}
