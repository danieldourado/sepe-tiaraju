using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour 
{
	public float timeTarget = 1f;

	public void Start () 
	{
		GameStateManager.OnGameEventChanged += CheckEvent;
	}

	private void CheckEvent(GameEvent ge) 
	{
		if(ge == GameEvent.Pause) Pause();
		//if(ge == GameEvent.MainMenu) Pause();//Se nao sair do pause, sceneloader nao funciona,
		//pois tem invoke com tempo, e pause para o tempo.
	}

	void Pause ()
	{
		if(timeTarget > 0)
			timeTarget = 0;
		else
			timeTarget = 1;
	}

	void Update()
	{
		Time.timeScale = timeTarget;
	}
}
