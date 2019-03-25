using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interactions : MonoBehaviour 
{
	public int timeLimitInMilliseconds = 3;

	private List<InteractionVO> interactionList;

	void Awake()
	{
		interactionList = new List<InteractionVO>();
	}

	void FixedUpdate () 
	{
		//ExecuteInteraction(interactionList.Pop());
	}

	void ExecuteInteraction(InteractionVO interaction)
	{

	}

	public void AddInteraction(InteractionVO interaction)
	{
		interactionList.Add(interaction);
	}
}


public class InteractionVO
{
	public enum InteractionType
	{
		Atack,
		Probe
	}
}

static class ListExtension
{
	public static T Pop<T>(this List<T> list)
	{
		int count = list.Count;
		T r = list[count-1];
		list.RemoveAt(count-1);
		return r;
	}
}