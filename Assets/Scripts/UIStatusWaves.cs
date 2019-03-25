using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIStatusWaves : MonoBehaviour 
{
	Text text;
	Waves waves;
	void Start()
	{
		text = GetComponent<Text>();
		waves = FindObjectOfType<Waves>();
	}
	
	void Update () 
	{
		text.text  = waves.currentWave+"/"+waves.tempoDasWaves.Count;
	}
}
