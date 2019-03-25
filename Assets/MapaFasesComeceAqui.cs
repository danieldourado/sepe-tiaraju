using UnityEngine;
using System.Collections;

public class MapaFasesComeceAqui : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		//bool active = Main.instance.score.playerData.gameRecordPoint.Count == 0;
		//gameObject.SetActive(active);
		GameStateManager.OnGameStateChangeToWaveStarted += Disable;
	}

	void Disable ()
	{
		gameObject.SetActive(false);
	}

	void OnDestroy()
	{
		GameStateManager.OnGameStateChangeToWaveStarted -= Disable;
	}
}
