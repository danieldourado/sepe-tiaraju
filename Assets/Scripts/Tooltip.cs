using UnityEngine;
using System.Collections;

public class Tooltip : MonoBehaviour 
{
	public GameEvent eventToHide;

	public void Awake()
	{
		GameStateManager.OnGameEventChanged += CheckIfEventToHide;
	}

	public void Start()
	{
		transform.SetAsFirstSibling();
	}

	void CheckIfEventToHide (GameEvent ge)
	{
		if(ge == eventToHide)
		{
			Destroy(gameObject);
		}
	}

	public void OnDestroy()
	{
		GameStateManager.OnGameEventChanged -= CheckIfEventToHide;
	}
}
