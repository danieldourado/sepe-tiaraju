using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour 
{
	public float timeToChange = 2.5f;
	// Use this for initialization
	void Start () {
		Invoke("Load",timeToChange);
	}

	public void Load () 
	{
		var a = Main.instance;
	}
}
