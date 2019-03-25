using UnityEngine;
using System.Collections;

public class UpgradesScreen : MonoBehaviour 
{
	public GameObject torres;
	public GameObject especiais;

	public void ShowTowers()
	{
		torres.SetActive(true);
		especiais.SetActive(false);
	}

	public void ShowSpecials()
	{
		torres.SetActive(false);
		especiais.SetActive(true);
	}
}
