using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour 
{
	bool isShown;
	public void Start () 
	{
		GameStateManager.OnGameEventChanged += CheckEvent;
		Hide();
	}

	private void CheckEvent(GameEvent ge) 
	{
		if(ge == GameEvent.ShowPauseScreen) 
		{
			if(isShown) Hide();
			else Show();
		}
	}

	void Update()
	{
		var currPos = transform.position;
		//transform.localPosition = new Vector3(currPos.x, currPos.y, -200f);
	}

	void Hide ()
	{
		transform.position = new Vector3(-2000f, 0f, -200f);
		isShown = false;
	}

	void Show ()
	{
		iTween.MoveTo(gameObject, iTween.Hash("x", 0f, "y", 0f, "z", -200f, "time", 0.1f, "ignoretimescale", true));
		isShown = true;
	}

	void OnDestroy()
	{
		GameStateManager.OnGameEventChanged -= CheckEvent;
	}
}
