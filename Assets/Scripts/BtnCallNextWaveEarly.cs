using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnCallNextWaveEarly : MonoBehaviour 
{
	Waves wave;
	Button button;
	void Start () {
		wave = FindObjectOfType<Waves>();
		button = GetComponent<Button>();
		button.interactable = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		button.interactable = wave.CanCallNextWaveEarly();
	}
}
