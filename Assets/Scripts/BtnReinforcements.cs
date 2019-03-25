using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnReinforcements : MonoBehaviour 
{
	Reinforcements reinforcements;
	Button button;
	void Start () 
	{
		reinforcements = FindObjectOfType<Reinforcements>();
		button = GetComponent<Button>();
		button.interactable = false;
	}

	void Update () 
	{
		button.interactable = reinforcements.IsAvaliable();
	}
}
