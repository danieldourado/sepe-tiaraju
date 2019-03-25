using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour 
{
	bool isShown;
	public void Start () 
	{
		GameStateManager.OnGameEventChanged += CheckEvent;
		Hide();
	}
	
	private void CheckEvent(GameEvent ge) 
	{
		if(ge == GameEvent.GameOver) 
		{
			if(isShown) Hide();
			else Show();
		}
	}
	
	void Hide ()
	{
		transform.position = new Vector3(-2000f, 0f);
		isShown = false;
	}
	
	void Show ()
	{
		GameStateManager.GameEvent = GameEvent.Pause;
		iTween.MoveTo(gameObject, iTween.Hash("x", 0f, "y", 0f, "time", 0.1f, "ignoretimescale", true));
		isShown = true;
	}
	
	void OnDestroy()
	{
		GameStateManager.OnGameEventChanged -= CheckEvent;
	}
}
