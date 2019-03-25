using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuScreen : MonoBehaviour 
{
	public List<GameObject> screens;

	void Start () 
	{
		//OpenScreen(screens[0]);	
		//Main.instance.DisableLoadingScreen();
	}

	public void OpenScreen(GameObject screenToActivate)
	{
		foreach(GameObject screen in screens)
		{
			screen.SetActive(screenToActivate == screen);
		}
	}

	public void OnEnable()
	{
		OpenScreen(screens[0]);
	}

	
}
