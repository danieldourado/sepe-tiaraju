using UnityEngine;
using System.Collections;

public class WinScreen : MonoBehaviour
{
	public GameObject estrela1, estrela2, estrela3;

	bool isShown;
	public void Start () 
	{
		GameStateManager.OnGameEventChanged += CheckEvent;
		Hide();
	}
	
	private void CheckEvent(GameEvent ge) 
	{
		if(ge == GameEvent.Win) 
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
		ShowStars();

		GameStateManager.GameEvent = GameEvent.Pause;
		iTween.MoveTo(gameObject, iTween.Hash("x", 0f, "y", 0f, "time", 0.1f, "ignoretimescale", true));
		isShown = true;
	}

	void ShowStars ()
	{
		var gs = FindObjectOfType<GameScore>();
		var ammountOfStars = gs.CalculateStars();

		estrela2.SetActive(false);
		estrela3.SetActive(false);

		if(ammountOfStars == 2)
			estrela2.SetActive(true);
		if(ammountOfStars == 3)
			estrela3.SetActive(true);
	}
	
	void OnDestroy()
	{
		GameStateManager.OnGameEventChanged -= CheckEvent;
	}
}
