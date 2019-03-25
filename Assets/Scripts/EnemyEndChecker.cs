using UnityEngine;
using System.Collections;

public class EnemyEndChecker : MonoBehaviour 
{
	private Collider2D endTrigger;
	void Awake () 
	{
		endTrigger = GameObject.FindGameObjectWithTag("EnemiesEndLocation").GetComponent<Collider2D>();
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider == endTrigger)
		{
			SetUnitFinished();
		}
	}

	void SetUnitFinished ()
	{

	}
}
