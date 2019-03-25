using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpecialHabilityButton : MonoBehaviour {

	SpecialHability specialHability;
	Button button;
	void Start () 
	{
		var list = FindObjectsOfType<SpecialHability>();

		foreach(SpecialHability tempsh in list)
		{
			if(tempsh.eventToRespondTo == GetComponent<EventDispatcher>().eventToDispatch)
			{
				specialHability = tempsh;
			}
		}
		button = GetComponent<Button>();
		button.interactable = false;
	}
	
	void Update () 
	{
		button.interactable = specialHability.IsAvaliable();
	}
}
