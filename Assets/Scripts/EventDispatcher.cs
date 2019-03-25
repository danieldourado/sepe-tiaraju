using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventDispatcher : MonoBehaviour 
{
	public GameEvent eventToDispatch;
	public List<GameEvent> listOfEvents;

	public void OnClick()
	{
		if(listOfEvents.Count == 0)
			GameStateManager.GameEvent = eventToDispatch;
		else
		{
			foreach(GameEvent tempEvent in listOfEvents)
			{
				GameStateManager.GameEvent = tempEvent;
			}
		}
	}
}
