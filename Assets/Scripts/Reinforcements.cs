using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Reinforcements : MonoBehaviour 
{

	[HideInInspector]
	public bool isSelected;
	public int numberOfReinforcements = 2;
	public GameObject reinforcementPrefab;
	public float timeToExpire = 20f;
	public ReloadTimer timer;

	List<GameObject> listOfWarriors;

	public void Start () 
	{
		GameStateManager.OnGameEventChanged += CheckEvent;
		timer = gameObject.AddComponent<ReloadTimer>();
		timer.Setup(timeToExpire, true);
	}
	
	private void CheckEvent(GameEvent ge)
	{
		if(ge == GameEvent.Reinforcements) ReinforcementsSelectedHandler();
	}
	
	void ReinforcementsSelectedHandler ()
	{
		if(isSelected)
		{
			FindObjectOfType<TouchOrganizer>().Hide();
		}
		else
		{
			FindObjectOfType<TouchOrganizer>().Hide();
			isSelected = true;
			Debug.Log("Reinforcements Selected");
		}
	}
	
	public void Hide ()
	{
		if(isSelected)
		{
			Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			FindObjectOfType<GroundFlag>().SetTarget(target);


			target.z = transform.position.z;

			var anchorPoint = target;
			transform.position = target;

			listOfWarriors = new List<GameObject>();

			GameObject tempWarrior;
			
			for(int i = 1; i<=numberOfReinforcements; i++)
			{
				tempWarrior = Instantiate<GameObject>(reinforcementPrefab);
				tempWarrior.transform.position = transform.position;

				tempWarrior.GetComponent<AllyDuel>().SetAsReinforcementWarrior(anchorPoint);
				//tempWarrior.GetComponent<MoverData>().speed *=2;
				var expirer = tempWarrior.AddComponent<Expirer>();
				expirer.Setup(timeToExpire);
				listOfWarriors.Add(tempWarrior);
			}
			timer.Start();


		}
		
		isSelected = false;
		Debug.Log("Reinforcements deSelected");
	}

	public bool IsAvaliable ()
	{
		return timer.isReloaded;
	}
}
