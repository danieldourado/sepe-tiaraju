using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradesScreenEstrelas : MonoBehaviour 
{
	private Text texto;

	void Start () 
	{
		texto = GetComponent<Text>();
	}
	
	void Update () 
	{
		texto.text = Main.instance.score.currentScoreStars.ToString();
	}
}
